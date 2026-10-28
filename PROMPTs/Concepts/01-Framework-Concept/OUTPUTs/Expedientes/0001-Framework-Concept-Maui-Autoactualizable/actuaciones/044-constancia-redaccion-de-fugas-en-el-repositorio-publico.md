| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-28 |
| Autor | Presidencia de la mesa |
| Corrige | — |

# Constancia — redacción de fugas en el repositorio público

La verificación E1-G del expediente 0002 encontró datos que no debían estar en este repositorio público. La constancia
041 tenía la dirección de la tailnet de la PC del PO y la serie del moto g42, y 23 archivos del Framework Concept tenían
rutas del directorio temporal de sesiones del anfitrión, en algunos casos con el usuario del sistema. Al revisarlos
apareció además el nombre del emulador de un proyecto privado. El PO pidió redactar sin perder información.

## Hecho

Se redactó en el lugar, como hizo el folio 039, en 26 archivos de `PROMPTs/Concepts/01-Framework-Concept/OUTPUTs/`.
Cada dato se reemplazó por un marcador que conserva su función en el texto:

| Marcador | Reemplaza | Apariciones |
| --- | --- | --- |
| `203.0.113.30` y `<serie-del-g42>` | La dirección del servidor de adb de la PC del PO y la serie del teléfono (constancia 041). Son los marcadores que ya usan los demás folios | 1 línea |
| `{dir-de-trabajo}` | La carpeta de trabajo de una sesión (ruta con el usuario del sistema) | 4 |
| `{dir-de-sesion}` | La carpeta de una sesión, sin la subcarpeta de trabajo | 1 |
| `{tmp-de-sesiones}` | La raíz del directorio temporal de sesiones del anfitrión. Con `/<proyecto>`, la carpeta del proyecto dentro de ella | 25 |
| `<privado>` | El nombre del emulador y del AVD de un proyecto privado, como ya estaba en otros lugares del relevamiento R2 | 8 |

El punto de montaje `/vm` queda como está: no identifica a nadie y es el sujeto del bloqueo por inodos del relevamiento
R2. Las rutas de dentro de los contenedores (`/home/dev/…` y `/home/runner/…`) tampoco cambian, porque son de la imagen y
no del anfitrión.

Después del cambio, un `git grep` sobre `PROMPTs/Concepts/` en busca de la ruta del home, la ruta del temporal de
sesiones, cualquier IPv4 de la tailnet, la serie del teléfono y el nombre privado no encuentra nada.

## Lo que no se hizo

- **La historia del repositorio sigue teniendo los datos**, en los commits anteriores a esta redacción (entre ellos
  `a4d26c8`, que agregó la constancia 041). Sacarlos de ahí exige reescribir la historia de `main`, y esa decisión es del
  PO.
- No se tocó nada fuera de `PROMPTs/Concepts/01-Framework-Concept/`.

## Pase

Archivo. El expediente sigue ARCHIVADO.
