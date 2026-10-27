| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-10-27 |
| Autor | Presidencia de la mesa |
| Corrige | — |

# Providencia — aprobación del PO: redacción de filtraciones previas, etiquetas del runner y cierre

```testimonio
ok, dale para adelante
```

| Canal | Fecha-hora | Fuente |
| --- | --- | --- |
| Chat de Claude Code en VS Code | 2026-10-27 | Respuesta del PO al plan de cierre en dos etapas (redacción y cierre) |

## Lo aprobado

1. **Redacción de las filtraciones S2 previas en `main`.** Se quita el nombre de la app privada de la organización de
   las dos `GitHub-Action-Guide.md` de `hdcm-dev/Lab-Documentos` y de la línea del `CHANGELOG.md` de
   `hdcm-dev/Lab-Documentos.Documentacion`; en su lugar queda «una app híbrida de referencia de la organización», que
   conserva el sentido (firma de distribución, TestFlight y APK firmado existen fuera de los repositorios de
   referencia). Las rutas absolutas del home del PO en los OUTPUTs de las guías 06 y 15 pasan a `<workspace>/`.
2. **Etiquetas del runner aceptadas como publicadas.** `i7infra-dev` e `i7infra-runner-dev` quedan publicadas en los
   workflows y documentos ya fusionados; no se redactan. Es una aceptación expresa del PO, no una omisión.
3. **Cierre del expediente.** Tras la redacción, se procede al cierre: medición y limpieza del g42 si está libre,
   limpieza de contenedores e intermedios propios, folio de archivo y carátula en ARCHIVADO.

## Efecto

La redacción va por un PR por repositorio con el ciclo de conformación automática. La historia de git anterior no se
reescribe: la redacción alcanza al árbol vigente de `main`.
