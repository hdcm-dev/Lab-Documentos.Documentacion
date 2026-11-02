#!/usr/bin/env python3
"""Casos que el verificador automático no asoció (referencia antes del bloque o sin «l.»): ruta y rango a mano."""
import re, sys, os
raiz = sys.argv[1]
g = open(os.path.join(raiz,'Dot-Net-Integration-AI-Layer-Guide.md'),encoding='utf-8').read().split('\n')
def bloque(l):  # l = número de línea (1-based) de la apertura ``` 
    j=l; out=[]
    while not g[j].strip().startswith('```'): out.append(g[j]); j+=1
    return out
def norm(s): return re.sub(r'\s+',' ',s).strip()
casos = [
 (808,'Examples/13-Prueba-De-Arquitectura/src/MovilidadUrbana.PruebaDeArquitectura/Mutaciones/R4/GlobalUsing.cs',3,3),
 (812,'Examples/13-Prueba-De-Arquitectura/src/MovilidadUrbana.PruebaDeArquitectura/Mutaciones/R4/PropuestaConMensaje.cs',5,10),
 (983,'Examples/01-Chat-Basico/src/MovilidadUrbana.Ejemplos.ChatBasico/Configuracion/ComposicionDeIA.cs',37,40),
 (1118,'Examples/03-Salida-Estructurada/src/MovilidadUrbana.SalidaEstructurada/Application/Propuestas/LocalidadPropuesta.cs',15,21),
 (1227,'Examples/12-Anotaciones-Pareadas/src/*/Infrastructure/AI/SemanticKernel/ResultadosDeEncuestaPlugin.cs',8,16),
 (1241,'Examples/12-Anotaciones-Pareadas/src/*/Infrastructure/AI/AgentFramework/HerramientasDeResultados.cs',12,20),
 (1513,'Examples/09-Pruebas-Con-Cliente-Falso/src/MovilidadUrbana.Ejemplos.PruebasConClienteFalso/Infrastructure/AI/DetectorDeContextoTruncado.cs',25,64),
 (1949,'Examples/06-Tool-Calling/src/MovilidadUrbana.Ejemplos.ToolCalling/Infrastructure/AI/HerramientasDeLocalidades.cs',43,47),
 (2030,'Examples/07-Agente-Con-Aprobacion/src/MovilidadUrbana.Ejemplos.AgenteConAprobacion/Infrastructure/AI/DelChatAlAgente/LlamadaUnica.cs',8,16),
 (2199,'Examples/10-Workflow/src/MovilidadUrbana.Ejemplos.Orquestacion/Application/Encuesta/EncuestaComoProceso.cs',23,33),
 (2415,'Examples/08-Servidor-Y-Cliente-MCP/src/MovilidadUrbana.Ejemplos.Mcp.Servidor/Mcp/ServidorMcp.cs',80,90),
 (3515,'Examples/01-Chat-Basico/src/MovilidadUrbana.Ejemplos.ChatBasico/Configuracion/OpcionesDeIA.cs',56,77),
]
import glob
for l,p,a,b in casos:
    f = glob.glob(os.path.join(raiz,p)); 
    if len(f)!=1: print(l,'RUTA?',p,f); continue
    src=[norm(x) for x in open(f[0],encoding='utf-8').read().split('\n')]
    tr=src[a-1:b]
    bl=[norm(x) for x in bloque(l) if norm(x) and '…' not in x]
    ok=sum(1 for x in bl if x in tr); fuera=[x for x in bl if x not in src]
    print(l, 'OK' if ok==len(bl) else ('CORRIDO' if not fuera else 'DIFIERE'), f'{ok}/{len(bl)}', os.path.relpath(f[0],raiz), f'l.{a}-{b}', fuera[:3])
