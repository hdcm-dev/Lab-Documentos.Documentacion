using System.Reflection;
using System.Reflection.Emit;

namespace MovilidadUrbana.PruebaDeArquitectura.Tests.Cableado;

/// <summary>
/// Inspector de dependencias sobre lo compilado. Para cada tipo mira la firma (base, interfaces, campos,
/// propiedades, eventos, parámetros, retornos, restricciones genéricas y atributos) y, si se pide, el
/// cuerpo de cada método: lee el IL y resuelve cada token de tipo, campo o método. Los tipos que genera
/// el compilador (clausuras, máquinas de estado de async) están en el mismo ensamblado y se inspeccionan
/// igual que los escritos a mano.
/// </summary>
public static class ReglaDeCapas
{
    public sealed record Violacion(Type Origen, Type Destino, string Donde)
    {
        public override string ToString() => $"{Origen.FullName} → {Destino.FullName} ({Donde})";
    }

    private const BindingFlags Todo =
        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;

    private static readonly Dictionary<short, OpCode> Codigos =
        typeof(OpCodes).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(f => (OpCode)f.GetValue(null)!)
            .ToDictionary(o => o.Value);

    public static IReadOnlyList<Violacion> Violaciones(IEnumerable<Type> tipos, Func<Type, bool> prohibido, bool leerCuerpo = true)
    {
        var encontradas = new List<Violacion>();
        foreach (var tipo in tipos)
        {
            void Revisar(Type? nombrado, string donde)
            {
                foreach (var t in Expandir(nombrado))
                    if (prohibido(t)) encontradas.Add(new Violacion(tipo, t, donde));
            }
            void RevisarAtributos(IEnumerable<CustomAttributeData> atributos, string donde)
            {
                foreach (var a in atributos)
                {
                    Revisar(a.AttributeType, $"atributo de {donde}");
                    foreach (var arg in a.ConstructorArguments.Concat(a.NamedArguments.Select(n => n.TypedValue)))
                        if (arg.Value is Type comoValor) Revisar(comoValor, $"argumento de atributo de {donde}");
                }
            }

            Revisar(tipo.BaseType, "base");
            foreach (var i in tipo.GetInterfaces()) Revisar(i, "interfaz");
            RevisarAtributos(tipo.GetCustomAttributesData(), "tipo");
            if (tipo.IsGenericTypeDefinition)
                foreach (var g in tipo.GetGenericArguments()) foreach (var r in g.GetGenericParameterConstraints()) Revisar(r, "restricción genérica");

            foreach (var f in tipo.GetFields(Todo)) { Revisar(f.FieldType, $"campo {f.Name}"); RevisarAtributos(f.GetCustomAttributesData(), $"campo {f.Name}"); }
            foreach (var p in tipo.GetProperties(Todo)) { Revisar(p.PropertyType, $"propiedad {p.Name}"); RevisarAtributos(p.GetCustomAttributesData(), $"propiedad {p.Name}"); }
            foreach (var e in tipo.GetEvents(Todo)) Revisar(e.EventHandlerType, $"evento {e.Name}");

            foreach (var m in tipo.GetMethods(Todo).Cast<MethodBase>().Concat(tipo.GetConstructors(Todo)))
            {
                if (m is MethodInfo mi)
                {
                    Revisar(mi.ReturnType, $"retorno de {m.Name}");
                    if (mi.IsGenericMethodDefinition)
                        foreach (var g in mi.GetGenericArguments()) foreach (var r in g.GetGenericParameterConstraints()) Revisar(r, $"restricción genérica de {m.Name}");
                }
                foreach (var p in m.GetParameters()) { Revisar(p.ParameterType, $"parámetro de {m.Name}"); RevisarAtributos(p.GetCustomAttributesData(), $"parámetro de {m.Name}"); }
                RevisarAtributos(m.GetCustomAttributesData(), $"método {m.Name}");

                if (!leerCuerpo) continue;
                var cuerpo = m.GetMethodBody();
                if (cuerpo is null) continue;
                foreach (var v in cuerpo.LocalVariables) Revisar(v.LocalType, $"variable local de {m.Name}");
                foreach (var t in TiposEnElIL(m, cuerpo)) Revisar(t, $"cuerpo de {m.Name}");
            }
        }
        return encontradas.DistinctBy(v => v.ToString()).OrderBy(v => v.ToString(), StringComparer.Ordinal).ToList();
    }

    private static IEnumerable<Type> Expandir(Type? t)
    {
        if (t is null || t.IsGenericParameter) yield break;
        if (t.HasElementType) { foreach (var x in Expandir(t.GetElementType())) yield return x; yield break; }
        yield return t;
        if (t.IsGenericType)
            foreach (var a in t.GetGenericArguments())
                foreach (var x in Expandir(a)) yield return x;
    }

    private static IEnumerable<Type> TiposEnElIL(MethodBase metodo, MethodBody cuerpo)
    {
        var il = cuerpo.GetILAsByteArray() ?? [];
        var modulo = metodo.Module;
        var delTipo = metodo.DeclaringType is { IsGenericType: true } dt ? dt.GetGenericArguments() : null;
        var delMetodo = metodo.IsGenericMethod ? metodo.GetGenericArguments() : null;

        for (var i = 0; i < il.Length;)
        {
            var op = il[i] == 0xFE ? Codigos[unchecked((short)(0xFE00 | il[i + 1]))] : Codigos[il[i]];
            i += op.Size;
            switch (op.OperandType)
            {
                case OperandType.InlineMethod or OperandType.InlineField or OperandType.InlineType or OperandType.InlineTok:
                    var miembro = modulo.ResolveMember(BitConverter.ToInt32(il, i), delTipo, delMetodo);
                    i += 4;
                    switch (miembro)
                    {
                        case Type t: yield return t; break;
                        case FieldInfo f: yield return f.DeclaringType!; yield return f.FieldType; break;
                        case MethodBase mb:
                            if (mb.DeclaringType is { } d) yield return d;
                            if (mb is MethodInfo r) { yield return r.ReturnType; foreach (var g in r.GetGenericArguments()) yield return g; }
                            foreach (var p in mb.GetParameters()) yield return p.ParameterType;
                            break;
                    }
                    break;
                case OperandType.InlineNone: break;
                case OperandType.ShortInlineBrTarget or OperandType.ShortInlineI or OperandType.ShortInlineVar: i += 1; break;
                case OperandType.InlineVar: i += 2; break;
                case OperandType.InlineI8 or OperandType.InlineR: i += 8; break;
                case OperandType.InlineSwitch: i += 4 + 4 * BitConverter.ToInt32(il, i); break;
                default: i += 4; break;   // InlineBrTarget, InlineI, InlineSig, InlineString, ShortInlineR
            }
        }
    }
}
