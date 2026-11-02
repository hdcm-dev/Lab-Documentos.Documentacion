# E3 · Tramo 2 · Parte II · Marco (capítulos 2–4)

Etapa E3, tramo 2 de 6 (`../05-Plan-Integrado.md` §5 E3). Fecha: 2026-11-01. Registro de sólo agregado. Recuento y compuertas: `Registro-Por-Parte.md` §3.

## Índice

1. [Definiciones](#1-definiciones)
2. [Qué se hizo](#2-qué-se-hizo)
3. [Cambios de E1 y recortes en el tramo](#3-cambios-de-e1-y-recortes-en-el-tramo)
4. [Decisiones de edición](#4-decisiones-de-edición)
5. [Pendientes para los tramos siguientes](#5-pendientes-para-los-tramos-siguientes)
6. [Archivos tocados](#6-archivos-tocados)

## 1. Definiciones

- **Alias:** ancla vieja (`sM`, `sM-k`, `sM-preguntas`) que se conserva junto a la nueva (`cN`, `cN-k`) para que los enlaces de fuera sigan resolviendo (`../E2/Anclas-Viejo-Nuevo.md`).
- **Número visible:** el número que lee la persona. En este tramo todo número visible de la Parte II está en la numeración nueva (capítulo = viejo + 1); el ancla puede seguir siendo la vieja.

## 2. Qué se hizo

1. **Encabezados** según el índice congelado (`../E2/Indice-Del-Libro.md`): «Capítulo 2 · «IA ya es parte del stack»…», «Capítulo 3 · Escenarios, contextos y actores», «Capítulo 4 · Mapa conceptual: capas, escaleras y tablas de entrada». Secciones 3.1–3.5 y 4.1–4.5; las preguntas pasan a 3.6 y 4.6 (`c3-preguntas`, `c4-preguntas`). Cada encabezado conserva su alias (`s1`, `s2`, `s2-1`…`s2-5`, `s2-preguntas`, `s3`, `s3-1`…`s3-5`, `s3-preguntas`).
2. **Numeración visible**: las remisiones de los tres capítulos muestran la numeración nueva (§N+1; capítulo entero como «capítulo N»), también dentro de la Figura 4.2; los enlaces a los capítulos 2–4 apuntan a las anclas nuevas y el resto a las viejas (alias).
3. **Tablas y figuras numeradas** por capítulo (C-2.6): Figuras 2.1, 2.2, 4.1–4.3; Tablas 3.1–3.5, 4.1–4.5.
4. **Citas a P-n** (Parte I) donde el texto ya enunciaba el principio: P-7 en la tesis, P-6/P-8 en el principio rector, P-1 en el invariante, P-4/P-7 en la Figura 4.1.
5. **§3.0 «Doce términos en una línea» sale del capítulo 4** (C-2.3) y pasa al Anexo C como Tabla C.1 «Términos de base», con el ancla `s3-0` (alias, como pide `Anclas-Viejo-Nuevo.md`); las filas del glosario que decían «§3.0» dicen «Tabla C.1». El capítulo 4 remite al glosario en su párrafo de entrada.
6. **HE-01**: comillas rectas anidadas de la pregunta guía del capítulo 2 → “”.

## 3. Cambios de E1 y recortes en el tramo

| Id | Estado en el tramo 2 |
|---|---|
| CL-02 (C-1.3) | aplicado en 4.1: el invariante anuncia con frase propia las dos excepciones de la demo (chat por la sesión, que escribe sólo por herramientas sobre casos de uso; ayuda por `IAyuda`, que no escribe) y remite a §15.2 y a ADR-01 (§14.2) |
| CL-07 (D-28 a) | aplicado en 3.2, CTX-LOCAL: sale «hasta el 2026-10-28, en un servidor que atendía a otros clientes»; queda un solo proveedor |
| CL-01, CL-03 | hechos en el tramo 1 |
| CL-04, CL-05 | nada en el libro |
| CL-06, CL-08 | fuera del tramo (caps. 7 y 9) |
| C-2.2 Historia | 0 bloques en la Parte II (ya no había en la 0.11.0) |
| C-2.3 glosario | §3.0 trasladada (ver §2.5) |
| Prácticas → README (D-11 d) | no hay Prácticas en los caps. 2–4: nada que trasladar |
| Excepción I-5 / ADR-01 sí/no | no aplica: los caps. 2–4 no tienen «En este laboratorio» |
| Autocontención | el capítulo 4 define sus escaleras y capas sin remitir a versiones anteriores; HE-11 = 0 en la parte |

## 4. Decisiones de edición

- **Tabla C.1 en el Anexo C ahora, no en el tramo de Anexos:** borrar §3.0 sin trasladarla dejaba el glosario remitiendo a una definición inexistente (rompe la autocontención). Se movió tal cual, con los números visibles nuevos; la fusión con §4.1 (cap. 5) y la columna de definición del glosario quedan para los tramos 3 y 6. Es la única edición fuera de la Parte II, además de ninguna en los tramos previos.
- **Recortes para el tope (3.700):** el párrafo de la diapositiva (cap. 2) y el de la faceta *AI Engineer* (3.3) se condensaron sin perder afirmaciones ni referencias; leyendas de tabla breves.
- **«Estás en»** se conserva: los capítulos 2–4 tienen forma propia (0.4, Tabla 0.2).

## 5. Pendientes para los tramos siguientes

1. Anexos: 12.886 palabras contra 12.100 (sube 245 por la Tabla C.1). El tramo de Anexos fusiona la Tabla C.1, §4.1 y la tabla del glosario (C-2.3) y recorta.
2. Las líneas de §4.1 («Qué **no** es cada término… en [§3.0](#s3-0)») y §6 («([§3.0](#s3-0))») siguen mostrando «§3.0»: el enlace resuelve; el número visible lo cambian los tramos 3 y 4.
3. El control docs-guard «mermaid-arroba» todavía no está en `tools/docs-guard/dg.py`; se aplicó el mismo criterio a mano (0 arrobas, 0 `#64;`).
4. `verificar.sh` completo y filtro U-7.1, al cierre de E3.

## 6. Archivos tocados

| Archivo (LD) | sha256 antes | sha256 después |
|---|---|---|
| `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md` | `95d8b0d35cc9be999ada788ed7e4b90fac59e5b68d2e41859b5efdaf898d94c9` | `e182b1458b936fa422ef6d34890d355c76f0ecc0705f9643140bcc7a70f155b9` |

Sin commit, push ni PR. Ningún README de ejemplos tocado (no había Prácticas en el tramo). No se tocaron archivos comunes ni carpetas de otras sesiones. Sin mensajes ajenos a mitad de turno.
