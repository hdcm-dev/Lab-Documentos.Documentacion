# E-A02 — Contrato traces: ancla por línea vs. por símbolo (dos CU y dos reglas sin identificador)

Método: manifiesto plano (id|tipo|modo|ruta|ancla|token) y validador Python de 40 líneas, corridos con python3 -I. Identificadores CU-LOC-01, CU-ENC-01, RN-LOC-01, RN-LOC-02 asignados por el ensayo (provisionales: MovilidadUrbana no tiene CU ni RN, R05:73).
Fecha-hora: 2026-10-26T15:08-03:00 · Quién: comisión C-ANALISTA

## Manifiesto
```
# Manifiesto de trazas de ensayo (formato plano: id|tipo|modo|ruta|ancla|token esperado)
CU-LOC-01|cu|linea|src/MovilidadUrbana.MAUI/Application/Localidades/LocalidadService.cs|13|SaveAsync
CU-LOC-01|cu|simbolo|src/MovilidadUrbana.MAUI/Application/Localidades/LocalidadService.cs|SaveAsync|SaveAsync
CU-LOC-01|cu|simbolo|src/MovilidadUrbana.MAUI/Pages/LocalidadEditorPage.xaml|AutomationId="guardar"|guardar
CU-LOC-01|cu|simbolo|tests/MovilidadUrbana.MAUI.Tests/LocalidadEditorViewModelTests.cs|GuardarNuevaAvisaYVuelve|GuardarNuevaAvisaYVuelve
CU-ENC-01|cu|linea|src/MovilidadUrbana.MAUI/Application/Encuestas/EncuestaService.cs|70|RegistrarAsync
CU-ENC-01|cu|simbolo|src/MovilidadUrbana.MAUI/Application/Encuestas/EncuestaService.cs|RegistrarAsync|RegistrarAsync
CU-ENC-01|cu|simbolo|tests/MovilidadUrbana.MAUI.Tests/EncuestaViewModelTests.cs|RecorreYRegistra|RecorreYRegistra
RN-LOC-02|rn|linea|src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs|30|MismaLocalidad
RN-LOC-02|rn|simbolo|src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs|MismaLocalidad|MismaLocalidad
RN-LOC-02|rn|simbolo|src/MovilidadUrbana.ApiWeb/Domain/Rules/LocalidadRules.cs|MismaLocalidad|MismaLocalidad
RN-LOC-02|rn|simbolo|src/MovilidadUrbana.Web/Domain/Rules/LocalidadRules.cs|MismaLocalidad|MismaLocalidad
RN-LOC-02|rn|simbolo|src/MovilidadUrbana.MAUI/Application/Localidades/LocalidadService.cs|Ya existe una localidad con ese nombre|Ya existe
RN-LOC-02|rn|simbolo|tests/MovilidadUrbana.UnitTests/LocalidadRulesTests.cs|MismaLocalidadCompara|MismaLocalidadCompara
RN-LOC-01|rn|simbolo|src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs|LargoMaximoDelNombre = |60
RN-LOC-01|rn|uso|src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs|NombreValido|LargoMaximoDelNombre
```
## Corrida A — árbol real (/LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor, 8fb4c3a), validador v1
```
OK    CU-LOC-01 linea   src/MovilidadUrbana.MAUI/Application/Localidades/LocalidadService.cs:13 espera «SaveAsync»
OK    CU-LOC-01 simbolo src/MovilidadUrbana.MAUI/Application/Localidades/LocalidadService.cs#SaveAsync -> 13 huella=2b6b8cc61a
OK    CU-LOC-01 simbolo src/MovilidadUrbana.MAUI/Pages/LocalidadEditorPage.xaml#AutomationId="guardar" -> 64 huella=95d7033f26
OK    CU-LOC-01 simbolo tests/MovilidadUrbana.MAUI.Tests/LocalidadEditorViewModelTests.cs#GuardarNuevaAvisaYVuelve -> 46 huella=eeb835de2f
OK    CU-ENC-01 linea   src/MovilidadUrbana.MAUI/Application/Encuestas/EncuestaService.cs:70 espera «RegistrarAsync»
OK    CU-ENC-01 simbolo src/MovilidadUrbana.MAUI/Application/Encuestas/EncuestaService.cs#RegistrarAsync -> 70 huella=c49a14ac48
OK    CU-ENC-01 simbolo tests/MovilidadUrbana.MAUI.Tests/EncuestaViewModelTests.cs#RecorreYRegistra -> 90 huella=26ab3399af
OK    RN-LOC-02 linea   src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs:30 espera «MismaLocalidad»
OK    RN-LOC-02 simbolo src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs#MismaLocalidad -> 30 huella=7a3ae521d8
OK    RN-LOC-02 simbolo src/MovilidadUrbana.ApiWeb/Domain/Rules/LocalidadRules.cs#MismaLocalidad -> 30 huella=7a3ae521d8
OK    RN-LOC-02 simbolo src/MovilidadUrbana.Web/Domain/Rules/LocalidadRules.cs#MismaLocalidad -> 30 huella=7a3ae521d8
OK    RN-LOC-02 simbolo src/MovilidadUrbana.MAUI/Application/Localidades/LocalidadService.cs#Ya existe una localidad con ese nombre -> 25 huella=0b00fe1605
OK    RN-LOC-02 simbolo tests/MovilidadUrbana.UnitTests/LocalidadRulesTests.cs#MismaLocalidadCompara -> 46 huella=81c094a7b2
OK    RN-LOC-01 simbolo src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs#LargoMaximoDelNombre = -> 12 huella=b4aeac77d4
FALLA RN-LOC-01 uso     src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs#NombreValido: ¿usa LargoMaximoDelNombre? no
TOTAL fallas=1
exit=1
```
## Corrida B — copia (git archive 8fb4c3a) con 2 líneas insertadas al principio de LocalidadRules.cs y EncuestaService.cs, validador v1
```
OK    CU-LOC-01 linea   src/MovilidadUrbana.MAUI/Application/Localidades/LocalidadService.cs:13 espera «SaveAsync»
OK    CU-LOC-01 simbolo src/MovilidadUrbana.MAUI/Application/Localidades/LocalidadService.cs#SaveAsync -> 13 huella=2b6b8cc61a
OK    CU-LOC-01 simbolo src/MovilidadUrbana.MAUI/Pages/LocalidadEditorPage.xaml#AutomationId="guardar" -> 64 huella=95d7033f26
OK    CU-LOC-01 simbolo tests/MovilidadUrbana.MAUI.Tests/LocalidadEditorViewModelTests.cs#GuardarNuevaAvisaYVuelve -> 46 huella=eeb835de2f
FALLA CU-ENC-01 linea   src/MovilidadUrbana.MAUI/Application/Encuestas/EncuestaService.cs:70 espera «RegistrarAsync»
OK    CU-ENC-01 simbolo src/MovilidadUrbana.MAUI/Application/Encuestas/EncuestaService.cs#RegistrarAsync -> 72 huella=c49a14ac48
OK    CU-ENC-01 simbolo tests/MovilidadUrbana.MAUI.Tests/EncuestaViewModelTests.cs#RecorreYRegistra -> 90 huella=26ab3399af
FALLA RN-LOC-02 linea   src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs:30 espera «MismaLocalidad»
OK    RN-LOC-02 simbolo src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs#MismaLocalidad -> 32 huella=7a3ae521d8
OK    RN-LOC-02 simbolo src/MovilidadUrbana.ApiWeb/Domain/Rules/LocalidadRules.cs#MismaLocalidad -> 30 huella=7a3ae521d8
OK    RN-LOC-02 simbolo src/MovilidadUrbana.Web/Domain/Rules/LocalidadRules.cs#MismaLocalidad -> 30 huella=7a3ae521d8
OK    RN-LOC-02 simbolo src/MovilidadUrbana.MAUI/Application/Localidades/LocalidadService.cs#Ya existe una localidad con ese nombre -> 25 huella=0b00fe1605
OK    RN-LOC-02 simbolo tests/MovilidadUrbana.UnitTests/LocalidadRulesTests.cs#MismaLocalidadCompara -> 46 huella=81c094a7b2
OK    RN-LOC-01 simbolo src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs#LargoMaximoDelNombre = -> 14 huella=b4aeac77d4
FALLA RN-LOC-01 uso     src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs#NombreValido: ¿usa LargoMaximoDelNombre? no
TOTAL fallas=3
exit=1
```
## Corrida C — además, MismaLocalidad renombrado a EsLaMismaLocalidad en la copia MAUI, validador v1 (sólo fallas)
```
FALLA CU-ENC-01 linea   src/MovilidadUrbana.MAUI/Application/Encuestas/EncuestaService.cs:70 espera «RegistrarAsync»
FALLA RN-LOC-02 linea   src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs:30 espera «MismaLocalidad»
FALLA RN-LOC-01 uso     src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs#NombreValido: ¿usa LargoMaximoDelNombre? no
TOTAL fallas=3
```
Lectura: v1 compara por subcadena; «EsLaMismaLocalidad» contiene «MismaLocalidad» y la traza de símbolo NO falla (falso negativo).
## Corrida D — validador v2 (límite de palabra) sobre la misma copia (sólo fallas)
```
FALLA CU-ENC-01 linea   src/MovilidadUrbana.MAUI/Application/Encuestas/EncuestaService.cs:70 espera «RegistrarAsync»
FALLA RN-LOC-02 linea   src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs:30 espera «MismaLocalidad»
FALLA RN-LOC-02 simbolo src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs#MismaLocalidad -> sin resolver huella=-
FALLA RN-LOC-01 uso     src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs#NombreValido: ¿usa LargoMaximoDelNombre? no
TOTAL fallas=4
```
## Corrida E — validador v2 sobre el árbol real (no regresión)
```
FALLA RN-LOC-01 uso     src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs#NombreValido: ¿usa LargoMaximoDelNombre? no
TOTAL fallas=1
```

## Anexo — fuente del validador v2
```python
import sys, hashlib, pathlib
root = pathlib.Path(sys.argv[1]); man = pathlib.Path(sys.argv[2])
fails = 0
for raw in man.read_text().splitlines():
    if not raw.strip() or raw.startswith('#'): continue
    tid, kind, mode, rel, anchor, token = raw.split('|')
    p = root / rel
    if not p.exists():
        print(f"FALLA {tid} {mode:7} {rel}: no existe"); fails += 1; continue
    lines = p.read_text(encoding='utf-8').splitlines()
    if mode == 'linea':
        n = int(anchor); ok = n <= len(lines) and token in lines[n-1]
        print(f"{'OK   ' if ok else 'FALLA'} {tid} {mode:7} {rel}:{n} espera «{token}»"); fails += not ok
    elif mode == 'simbolo':
        import re; rx = re.compile(r"(?<![A-Za-z0-9_])" + re.escape(anchor) + (r"(?![A-Za-z0-9_])" if anchor[-1:].isalnum() else "")); hits = [i+1 for i,l in enumerate(lines) if rx.search(l)]
        ok = len(hits) == 1 and token in lines[hits[0]-1]
        fp = hashlib.sha256('\n'.join(lines[hits[0]-1:hits[0]+3]).encode()).hexdigest()[:10] if hits else '-'
        print(f"{'OK   ' if ok else 'FALLA'} {tid} {mode:7} {rel}#{anchor.strip()} -> {':'.join(map(str,hits)) or 'sin resolver'} huella={fp}"); fails += not ok
    elif mode == 'uso':
        # la regla declarada debe usarse dentro de la verificación nombrada (cuerpo = línea del símbolo + 2)
        hits = [i for i,l in enumerate(lines) if anchor in l and '(' in l]
        body = '\n'.join(lines[hits[0]:hits[0]+3]) if hits else ''
        ok = token in body
        print(f"{'OK   ' if ok else 'FALLA'} {tid} {mode:7} {rel}#{anchor}: ¿usa {token}? {'sí' if ok else 'no'}"); fails += not ok
print(f"TOTAL fallas={fails}"); sys.exit(1 if fails else 0)
```
