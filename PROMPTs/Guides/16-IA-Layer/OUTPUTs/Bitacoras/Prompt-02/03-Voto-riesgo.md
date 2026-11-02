# Voto del jurado · función riesgo (Prompt 02)

Voto a ciegas sobre `02-Consolidado.md`. Veto acotado: privacidad/R-PRIV, afirmación no verificable, ruptura de compuertas, interferencia con otra sesión.

## Vetos

- **D-06 b** — afirmación no verificable sin cotejo: la corrida del Anexo F se toma como evidencia de 2026-07-28 sin ensayo registrado en esta pasada. Se levanta si la corrida está archivada con rótulo completo.
- **D-12 a** — tope fuera de la compuerta: deja la guía por encima del tope que mide `contar.sh` (44.330) y rompe la compuerta.
- **D-30 b** — contradice la ruta fijada por el PO y la carta, y renombrar un archivo puede chocar con otra sesión; es decisión del PO.

## Votos

| Id | Opción | Fundamento |
|---|---|---|
| D-01 | a | Sin cifra en el texto, no hay afirmación que envejezca; `contar.sh` es la fuente. |
| D-02 | a | Sólo texto: no toca código ni compuertas; los ADR nuevos agrandan la superficie a verificar. |
| D-03 | b | El grep previo evita romper `verificar.sh` y compuertas. |
| D-04 | c | Un umbral medible y, si falla, NO VERIFICADO: nada se afirma sin evidencia. |
| D-05 | b | Clasificar por capacidad conserva lo ya observado sin borrar evidencia. |
| D-06 | a | Ensayo nuevo T-3 antes de cambiar la versión (b vetada). |
| D-07 | a | El cambio mínimo mantiene válidas las anclas que verifican las compuertas de cabeceras. |
| D-08 | a | Neutral; sin riesgo. Sigue a la mayoría. |
| D-09 | a | El perfil vigente más «Decisión» es trazable al perfil. |
| D-10 | a | La tabla deja la procedencia verificable; la bitácora conserva el detalle. |
| D-11 | d | Comando y salida esperada se pueden verificar; el enlace queda chequeable. |
| D-12 | b | Se ajusta a la compuerta existente (a vetada). |
| D-13 | c | Coherente con D-07 a. |
| D-14 | c | Cada principio sale de un ADR existente: verificable, no inventado. |
| D-15 | a | No crea un principio sin ADR que lo respalde. |
| D-16 | b | Tope moderado, compatible con D-12 b. |
| D-17 | b | Autocontención con fuente citada; la remisión mantiene la trazabilidad. |
| D-18 | a | Patrón probado y divergencia declarada; no exige interpretar Rule-Forma. |
| D-19 | b | Condicional al dictamen de N-10: no presupone. |
| D-20 | c | Incluye contexto (1) y riesgos (9/11): cubre seguridad. |
| D-21 | b | Las mínimas tienen un alcance verificable. |
| D-22 | b | Un solo esquema evita colisiones; en un repo público no se usa prefijo de privado (RQ-PRV en a). |
| D-23 | c | Checklist binario con agente sin la guía y un humano: lo más verificable. |
| D-24 | b | El mapeo a OWASP es contrastable con fuente externa. |
| D-25 | a | Tope concreto y medible. |
| D-26 | c | Alcance acotado; V3/V4 sin evidencia en esta pasada. |
| D-27 | c | No agrega código nuevo a Examples ni toca compuertas; enlaza a un repo público. |
| D-28 | a | Promete sólo la infraestructura que existe; no describe servidores privados. |
| D-29 | b | Con N-04 abierto, `1.0.0-rc` afirmaría una madurez no verificada. |
| D-30 | a | Lo fijó el PO (b vetada). |
