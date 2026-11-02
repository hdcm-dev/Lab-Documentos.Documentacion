# Métrica — caso C0, ronda 3 (brazo A, conocimiento 1.2)

- Oráculo: `sellado/oraculo-O3-3.md`, sha256 `e553c186c996f1ca1f1ff91e7b813fbcab0322ae7c29bf811e60f5862e263a00` (coincide con el prefijo e553c186).
- Corridas: C0-r1 y C0-r2. Las dos auditorías las clasificaron **ANULADA**.
  - r1: hubo lecturas de Bash fuera de `./aislado` (llamadas 22–25 y 35) y esa salida terminó en la ficha (en `linea-de-base.md:27-31` y en `_requisitos.md`). La auditoría deja anotada también una lectura alternativa, VÁLIDA CON OBSERVACIÓN, para que la decida la presidencia.
  - r2: se corrió un `python3` fuera de `./aislado` que escribió la sección 7 de `A-01.md`, y el aplicador lo declaró.

## Resultado

Según F399, una corrida ANULADA no se mide. Por eso no calculé M1, M2 (heredadas y audiencia), M3, M5 ni M6, y tampoco corrí la compuerta. Ninguna de las dos corridas pasa.

| Corrida | Válida | M1 | M2 heredadas | M2 audiencia | M3 | M4 | M5 | M6 | Pasa |
|---|---|---|---|---|---|---|---|---|---|
| C0-r1 | ANULADA | n/m | n/m | n/m | n/m | 0 (informativo) | n/m | n/m | no |
| C0-r2 | ANULADA | n/m | n/m | n/m | n/m | 0 (informativo) | n/m | n/m | no |

El M4 que da el perito (`M4/README.md`) es de 0 invenciones en las dos corridas: en r1, 50 citas, 49 existen y 1 no se puede verificar porque viene de un anexo del marco; en r2, 52 citas y las 52 existen. Lo dejo sólo como información, porque no entra en el veredicto.

**M7, entre corridas:** no se puede calcular, porque no hay ninguna corrida válida.

## Defectos del conocimiento (aparte del oráculo)

- **D1:** las dos corridas se anularon por lo mismo: el aplicador procesó archivos con herramientas del host fuera de `./aislado`. El conocimiento y la carta no dicen claramente que todo cómputo (lectura, scripts) sobre el directorio de la corrida tiene que pasar por `./aislado`, ni qué hacer con los archivos que ya generó `./aislado`. **Arreglo:** escribir esa regla explícita en la carta y en el conocimiento, con un ejemplo, y decir si leer derivados de `salida/` hechos por `./aislado` está permitido.
- **D2:** en r1 hay dos lecturas posibles de la regla, ANULADA o VÁLIDA CON OBSERVACIÓN. **Arreglo:** que la presidencia fije el criterio en la regla de la carta 2.

## Errores del oráculo

No encontré ninguno: el oráculo no se contrastó porque no hay corridas válidas.

## Copias y barrido

En `corrida-r1/` y `corrida-r2/` están las copias de `salida/` y `coordinacion/`; en `sellado/`, el oráculo. En la copia de r2 (`inventario/c12b.txt` y `verificacion/verif.sh`) aparecían nombres de host e IP privadas, y los reemplacé por `<host>` y `<ip-privada>`. Después de eso el barrido da 0. En las corridas originales, `coordinacion/` volvió a quedar con permisos 000.
