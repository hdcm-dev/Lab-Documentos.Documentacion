using System.Reflection;
using System.Reflection.Emit;

namespace MovilidadUrbana.Asistente.Tests.Comun;

/// <summary>
/// Regla de dependencias por reflexión: un tipo del núcleo no puede nombrar un tipo de un espacio de nombres
/// prohibido, ni en su firma (base, interfaces, campos, propiedades, parámetros, retornos) ni dentro del
/// cuerpo de sus métodos. Para el cuerpo lee el IL y resuelve cada token de método, campo o tipo.
/// Cubre también los tipos que genera el compilador (máquinas de estado de async, clausuras de lambdas).
/// </summary>
public static class ReglaDeCapas
{
    private static readonly Dictionary<short, OpCode> Codigos =
        typeof(OpCodes).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(f => (OpCode)f.GetValue(null)!).ToDictionary(o => o.Value);

    private const BindingFlags Todo = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;

    public static IReadOnlyList<string> Violaciones(IEnumerable<Type> tipos, Func<string, bool> espacioProhibido)
    {
        var violaciones = new SortedSet<string>(StringComparer.Ordinal);
        foreach (var tipo in tipos)
        {
            void Revisar(Type? t, string donde)
            {
                foreach (var nombrado in Expandir(t))
                    if (nombrado.Namespace is { } ns && espacioProhibido(ns))
                        violaciones.Add($"{tipo.FullName} → {nombrado.FullName} ({donde})");
            }

            Revisar(tipo.BaseType, "base");
            foreach (var i in tipo.GetInterfaces()) Revisar(i, "interfaz");
            foreach (var f in tipo.GetFields(Todo)) Revisar(f.FieldType, $"campo {f.Name}");
            foreach (var p in tipo.GetProperties(Todo)) Revisar(p.PropertyType, $"propiedad {p.Name}");
            foreach (var m in tipo.GetMethods(Todo).Cast<MethodBase>().Concat(tipo.GetConstructors(Todo)))
            {
                if (m is MethodInfo mi) Revisar(mi.ReturnType, $"retorno de {m.Name}");
                foreach (var p in m.GetParameters()) Revisar(p.ParameterType, $"parámetro de {m.Name}");
                MethodBody? cuerpo;
                try { cuerpo = m.GetMethodBody(); } catch (Exception) { continue; }
                if (cuerpo is null) continue;
                foreach (var v in cuerpo.LocalVariables) Revisar(v.LocalType, $"variable local de {m.Name}");
                foreach (var t in TiposEnIL(m, cuerpo)) Revisar(t, $"cuerpo de {m.Name}");
            }
        }
        return violaciones.ToList();
    }

    private static IEnumerable<Type> Expandir(Type? t)
    {
        if (t is null) yield break;
        if (t.HasElementType) { foreach (var x in Expandir(t.GetElementType())) yield return x; yield break; }
        if (t.IsGenericParameter) yield break;
        yield return t;
        if (t.IsGenericType)
            foreach (var a in t.GetGenericArguments())
                foreach (var x in Expandir(a)) yield return x;
    }

    private static IEnumerable<Type> TiposEnIL(MethodBase metodo, MethodBody cuerpo)
    {
        var il = cuerpo.GetILAsByteArray() ?? [];
        var modulo = metodo.Module;
        var genericosDelTipo = metodo.DeclaringType is { IsGenericType: true } dt ? dt.GetGenericArguments() : null;
        var genericosDelMetodo = metodo.IsGenericMethod ? metodo.GetGenericArguments() : null;
        var i = 0;
        while (i < il.Length)
        {
            OpCode op;
            if (il[i] == 0xFE) { op = Codigos[unchecked((short)(0xFE00 | il[i + 1]))]; i += 2; }
            else { op = Codigos[il[i]]; i += 1; }

            switch (op.OperandType)
            {
                case OperandType.InlineMethod:
                case OperandType.InlineField:
                case OperandType.InlineType:
                case OperandType.InlineTok:
                {
                    var token = BitConverter.ToInt32(il, i);
                    i += 4;
                    MemberInfo? miembro = null;
                    try { miembro = modulo.ResolveMember(token, genericosDelTipo, genericosDelMetodo); } catch (Exception) { }
                    switch (miembro)
                    {
                        case Type t: yield return t; break;
                        case FieldInfo f: if (f.DeclaringType is { } fd) yield return fd; yield return f.FieldType; break;
                        case MethodBase m:
                            if (m.DeclaringType is { } md) yield return md;
                            if (m is MethodInfo mi) yield return mi.ReturnType;
                            foreach (var p in m.GetParameters()) yield return p.ParameterType;
                            break;
                    }
                    break;
                }
                case OperandType.InlineNone: break;
                case OperandType.ShortInlineBrTarget:
                case OperandType.ShortInlineI:
                case OperandType.ShortInlineVar: i += 1; break;
                case OperandType.InlineVar: i += 2; break;
                case OperandType.InlineI8:
                case OperandType.InlineR: i += 8; break;
                case OperandType.InlineSwitch: i += 4 + 4 * BitConverter.ToInt32(il, i); break;
                default: i += 4; break;   // InlineBrTarget, InlineI, InlineSig, InlineString, ShortInlineR
            }
        }
    }
}
