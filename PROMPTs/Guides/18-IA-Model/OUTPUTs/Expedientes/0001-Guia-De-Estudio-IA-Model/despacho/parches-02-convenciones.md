# Constancia de parches — lote 02 «local Convenciones.md»

Cuerpo de parches de la mesa, ronda 2. Documento intervenido: `Guides/IA/IA-Model/Convenciones.md`
(IAM-M3), en <worktree-guia>. Unidad de aplicación respetada: el documento quedó entero en cada
parche; ninguna salida verificada ni marca del verificador fue tocada (M3 no contiene ninguna).
Sin commits, conforme al despacho.

## PA-01 — exención de cifras históricas en §6.1

- **Hallazgos**: R2-FUN-01 (nivelado P2·E2), con R2-SIS-04 y R2-EDI-07 plegados a la misma
  dirección (opción b: legalizar la práctica citada en lugar de deshacer trabajo verificado).
- **Dirección votada**: asentar en M3 §6.1 que la cifra histórica o arquitectónica con cita
  primaria fechada queda exenta de la regla «sólo vía la tabla del documento 11»; la cifra del
  parque vigente sigue entrando sólo por esa tabla; con la condición de revisión de FUN-01.
- **Qué cambié**: agregué un párrafo al cierre de §6.1 (líneas 267–271), a continuación del
  párrafo que fija la regla general. Enuncia la exención con su fundamento (la cifra histórica
  envejece con su fuente, no con el catálogo; la sostiene su cita §2), reafirma que la cifra del
  parque vigente entra sólo vía la tabla del documento 11, y asienta la condición de revisión:
  si una cifra histórica pasa a usarse comparativamente contra el parque vigente, vuelve a la
  tabla. Trazado a «expediente 0001, ronda 2, hallazgo R2-FUN-01».
- **Líneas**: 267–271.

## PA-12 — criterio errata/recorrida en §4 y compuerta mermaid en §6.2

- **Hallazgos**: R2-REF-07 (P3·E2) y R2-REF-10 (P3·E1).
- **Dirección votada**: (a) una línea en §4 con el criterio que reconcilia ENT-04 y ENT-11 —
  defecto de contenido se corrige y se recorre; defecto de forma se asienta como errata con
  condición de recorrida —; (b) junto a los disparadores de §6.2, la compuerta de compilación
  mermaid (todo diagrama compila antes de promover o tras editarse).
- **Qué cambié**:
  - §4: párrafo breve al cierre de la sección (líneas 219–222), después de la regla «si una
    cifra no puede sostener ni protocolo ni cita, no se publica». Fija el criterio único para
    defectos sobre cifras ya verificadas, trazado a «expediente 0001, ronda 2, hallazgo
    R2-REF-07».
  - §6.2: viñeta nueva en la lista de disparadores de revisión (líneas 282–284), inmediatamente
    después del disparador del documento 11: compuerta de compilación mermaid — todo diagrama
    compila antes de promover el documento y se recompila tras cada edición que lo toque; un
    diagrama que no compila bloquea la promoción. Trazada a «expediente 0001, ronda 2, hallazgo
    R2-REF-10».
- **Líneas**: 219–222 (§4) y 282–284 (§6.2).

## Devueltos

Ninguno: ningún parche del lote tocaba salidas verificadas ni marcas del verificador.

## Observaciones

- La sección «8. Referencias de este documento» de M3 cita los folios 002, 009 y 011 como origen
  de las decisiones «expediente 0001»; los tres pasajes nuevos trazan a «ronda 2» con su hallazgo.
  Si la mesa quiere que esa entrada de Referencias mencione también el folio del veredicto de la
  ronda 2, es un ajuste fuera de la dirección votada de este lote: lo dejo anotado, no lo aplico.
