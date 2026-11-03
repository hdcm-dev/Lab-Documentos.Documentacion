| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-11-03 |
| Autor | Presidencia de la mesa conjunta (escribano) |
| Corrige | — |

# Constancia — redacción S2 previa al primer push, y barrido del expediente

Redacción S2: previa al primer push de la carpeta; ninguna pieza se modificó después de publicarse.

## 1. Por qué

El jurado ordenó, 3–0 y como propuesta 1 del plan (folio 011, R-Q2 y §3), retirar de todo folio que vaya al
repositorio público **la frase de explotación, la versión del contrato y el ejemplo con su cifra** del defecto
abierto del validador de `{servicio-privado}`, y reemplazarlos por «defecto de seguridad abierto del validador,
informado al responsable». Lo levantó el refutador (folio 010, R-9). Es un dato de un repositorio privado y un
defecto de seguridad sin corregir: `Expediente-Rules.md` §4, S2, segunda clase. La marca de redacción es la única
transformación de esas piezas (§3.3).

## 2. Piezas redactadas

Huella SHA-256 del original de la ruta de trabajo del rol (no versionado; queda en la carpeta de trabajo de la
presidencia, fuera del repositorio) y de la pieza ya redactada, antes de envolverla con la cabecera y el pase.

| Folio | Rol | Marcas | Huella del original | Huella de la pieza redactada |
| --- | --- | --- | --- | --- |
| 004 | Posición «Capa de IA» | 3: la regla y su frase de explotación; la versión del contrato; el ejemplo de atribución con su cifra | `b2ed145fd000c2e7e2249afc82af6603673f0aac0ae41f644f7e4b239e384875` | `1b29ab879963857dfd631e34713cc42cda1a4679fc1adfa41e5f867daeb14a43` |
| 008 | C-LLMOPS | 1: la descripción del mecanismo | `082cebaae4c8098aa14a65fec02e89f7c6ac9763ac22567e2efaa6570297b59f` | `3cb4e1b126130bbc98325ae42581314a6775136874d00ddc4188d0a4aa39d695` |
| 009 | C-DIDACTICA | 2: la entrada de ejemplo; el ejemplo de atribución con su cifra | `a61abba6a6d3fd75ff1b2806efc7c73ff8ce88df57dd4c4d3cd2f931f14cad6f` | `bfb08ca6492f77b90826d13d7e12b66caa4127c1bed1b2c5a4276ebe4c3d3e67` |
| 010 | Refutador | 2: la descripción del mecanismo y su frase; la versión del contrato | `20dd7398fc8f3f83741865b42a8ad1151aa7badf77f9646fa0016b960c2f7173` | `e2ade20b3a4eab1c975e225225371e203cd364bbfa1466fb828011e2336f9344` |

Sin marcas: 005, 006, 007 y 011, iguales al original; y **003, la posición de la sesión DocsAsCode, que se
incorpora tal cual por pedido de su parte** (huella del original
`4b725455578c8971b8c348e16b8fad1fbdbb7530d49d8992804a2bd6a32eb641`). En 003 había dos menciones al número de
expediente del repositorio privado, que el refutador señaló «en menor grado» y que el jurado no incluyó en su
orden. Con el ok expreso de la sesión DocsAsCode (2026-11-03), se redactaron con el texto que ella dictó:
«y un expediente de un repo privado» en `owner` y «(expediente del repo privado)» en la fila de su mesa. La misma
mención en 010 se marcó S2. La huella de arriba es la del original antes de esa redacción.

Las cartas (evidencia 001 a 009) llevan redactadas las rutas del host (tercera clase de S2) y sin el rótulo del
arnés; la carta de la presidencia (evidencia 001) lleva además redactada la lista de nombres de repositorios
privados que enumeraba para el barrido. Cada una declara en su primera línea la huella del registro crudo.

## 3. Barrido

Sobre todo lo que agrega este expediente (README, `.gitignore`, catorce folios, diez piezas de evidencia):
direcciones IP, rutas `/home` y `/vm`, puertos, correos, dominios privados, nombres de repositorios y
organizaciones privados, usuario del host y nombres de modelo junto a decisiones del producto privado.
Resultado: sin coincidencias más allá de las menciones genéricas que las propias reglas del despacho enumeran
(«/home/…, /vm/…») y de las citas a normas (por ejemplo «7.5» de ISO/IEC 42001). Los nombres de modelo sólo
aparecen junto a Lab-Geometria. El comando y su salida se informan con el commit.

**Lo que la redacción no hace.** Lo que se publique no se retira: cualquier corrección posterior será un folio
nuevo. El original sin redactar no entra al repositorio.

Sigue: resolución de la mesa · presidencia de la mesa · Cierra con: folio 013
