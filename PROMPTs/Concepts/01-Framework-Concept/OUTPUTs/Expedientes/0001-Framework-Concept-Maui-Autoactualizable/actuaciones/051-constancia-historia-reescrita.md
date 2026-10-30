| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-29 |
| Autor | Presidencia de la mesa |
| Cierra | «Lo que no se hizo» de la 044 y el pendiente «Historia del repositorio público» de la 048 y la 049 |

# Constancia — historia de los dos repositorios públicos reescrita

## Hecho

- **Decisión.** El PO aprobó reescribir la historia de Lab-Documentos y Lab-Documentos.Documentacion. Lo confirmó en
  esta línea y en la del expediente 0002, que antes había resuelto no reescribir (folios 252 y 258 de la 0002). Pidió
  cuidar lo avanzado en `Concepts/`, en el cuerpo SDEI y en la guía de IA.
- **Qué se borró.** Los datos que las constancias 044 y 045 y las redacciones del expediente 0002 (F1, F2 y F4 a F8)
  habían sacado sólo hacia adelante: rutas del directorio temporal de sesiones y del home del anfitrión, la serie del
  teléfono, la dirección de la tailnet, dos correos, el nombre de un emulador privado y nombres de organizaciones y
  proyectos privados. Se reemplazaron por los mismos marcadores que ya usaba la punta. Los correos de autor y committer
  pasaron a la dirección `noreply` de GitHub.
- **Cómo.** `git filter-repo` (v2.47.0) sobre clones espejo, con `--replace-text`, `--replace-message` y un mailmap,
  después de que las dos sesiones cerraron sus ramas. Primero se ensayó dos veces: el primer ensayo encontró que las
  líneas de comentario de una de las tablas se tomaban como texto a borrar, y se corrigió antes de publicar.
- **Verificación.** En la historia nueva de los dos repositorios, 0 apariciones de los patrones privados en todos los
  blobs y en los mensajes. El árbol de la punta nueva es idéntico al de la vieja (mismo SHA de árbol): no cambió
  ninguna línea vigente.
- **Publicación.** Force-push de `main` en los dos repositorios. En Lab-Documentos se liberaron por unos segundos la
  protección de `main` (force-push, `fw-ok` obligatorio y aplicación a administradores) y se restauró igual que antes,
  verificado por la API. El tag `docs-guard-v1.0.0` se recreó **anotado** sobre el commit que reemplaza a `c0766dc`,
  como pidió la resolución del folio 255 de la 0002.

| Repositorio | `main` anterior | `main` nuevo |
| --- | --- | --- |
| Lab-Documentos | `b25b71b` | `bf86669` |
| Lab-Documentos.Documentacion | `b9f4317` | `15d8452` |

## Consecuencias

- Los SHA citados en los folios, bitácoras, CHANGELOG e índices anteriores a esta constancia apuntan a la historia
  vieja. Los mapas viejo→nuevo y los respaldos completos de antes de reescribir se guardan fuera de los repositorios, en
  el resguardo privado del PO.
- `verificar.yml` de este repositorio fijaba docs-guard por un SHA de la historia vieja. La sesión de la 0002 lo
  refijó en `bf86669` (PR #41) y verificó que los árboles son idénticos y que el tag es anotado.
- **Límite:** GitHub conserva las referencias de los PR viejos (`refs/pull/*`), que no se pueden reescribir. Esas
  copias siguen accesibles desde las páginas de los PR. Para borrarlas hay que pedírselo a GitHub Support (decisión del
  PO).

## Pase

Archivo. El expediente sigue ARCHIVADO.
