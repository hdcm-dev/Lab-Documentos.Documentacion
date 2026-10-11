# Mesa · Ciclo 2 · 02 — Voto del juez de costo-beneficio

> Fecha: 2026-10-09. Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.3 (función 3) y §5.3. Insumo: `01-Consolidado.md` de esta carpeta.
> Función objetivo: ¿el costo de corregir (extensión, complejidad, riesgo de diluir) es menor al daño de no hacerlo? Voto por ítem, no en bloque.
> Criterio transversal de este juez en el ciclo 2: la guía creció 22 % en el ciclo 1, así que cada voto `PROCEDE` acota el alcance mínimo que repara el daño. En las [CONTRADICCIÓN] elijo la dirección que repara con menos texto nuevo y menos superficie que mantener; cuando las dos son compatibles, adopto la barata y bajo el tono de la cara.

| Id | Voto | Fundamento |
|---|---|---|
| C2-01 | PROCEDE | Lado A: descomentar `NU1603` para las dos políticas es una línea y el E1 muestra que con lock no da falso positivo (rc=0) y sin lock corta (rc=1); la defensa B no se agrega como pieza nueva (ver C2-03). |
| C2-02 | PROCEDE | `Exe Or WinExe` es un cambio de una condición más una línea sobre proyectos de prueba; dejarlo así saca del lock justo al tipo de proyecto del caso (WinForms/WPF) con CI en verde. |
| C2-03 | PROCEDE | Alcance mínimo: bajar el tono — decir que con lock el salto `requested`≠`resolved` no lo marca `NU1603` y se revisa en el diff de `packages.lock.json` al regenerarlo, rotulado [criterio]; un paso nuevo en `compuerta.sh` con experimento suma superficie a una compuerta que ya acumula defectos de copia. |
| C2-04 | PROCEDE | Una línea en A.3 y una celda en §6.4 con [B62]; fijar un SDK que sale de soporte en un mes sin decirlo es un daño concreto y barato de evitar. |
| C2-05 | PROCEDE | Lado A: editorconfig-checker fijado como paso por defecto y `check_text_policy.py` como ejemplo didáctico; la compuerta propia ya juntó nueve defectos de copia en dos ciclos y repararlos uno a uno cuesta más texto y mantenimiento que reordenar §5.2.5/A.11/B.1, con los límites (bit de ejecución, diagnóstico cp1252) declarados en una línea. |
| C2-06 | PROCEDE | Retirar `verificar.sh` como pieza copiable (resuelto por C2-05 A): quita texto y elimina una pieza que da «texto: OK» sobre el cp1252 del caso. |
| C2-07 | PROCEDE | Con C2-05 A el paso de texto no depende del módulo Python; si el ejemplo didáctico conserva `import editorconfig`, basta una línea de prerrequisito y `EditorConfig==0.17.1` en A.10. Una CI siempre roja que lo informa como violación es daño alto. |
| C2-08 | PROCEDE | `git update-index --chmod=+x` y `bash` en A.12 son dos líneas más un ítem en B.4; hoy el hook se ignora y el cp1252 entra, que es el caso disparador. |
| C2-09 | PROCEDE | Alcance mínimo: declarar el límite del hook (el grafo mira el disco) en una frase y corregir ESC-04; no agregar lógica nueva al hook. |
| C2-10 | PROCEDE | Una línea con `MSYS_NO_PATHCONV=1` (o WSL 2) citando la fuente del fabricante, manteniendo [no verificado]; el escenario disparador es Windows y los primeros comandos se rompen copiados. |
| C2-11 | PROCEDE | `safe.directory` en `postCreateCommand` es una línea; sin ella el hook nunca se activa en host Linux. No sumar `devcontainer up` a EA-1 si alarga el experimento: basta con anclarlo a la salida ya medida. |
| C2-12 | PROCEDE | Alcance mínimo: ampliar el glob de la variante B a `{cs,csproj,props,targets}`, marcar en A.1 qué variante activa el caso heredado y dar los tres estados en B.2 y §5.9 P2; no duplicar dos bloques completos activos. |
| C2-13 | PROCEDE | Lado A: «imagen por digest o runner alojado con `setup-*` por SHA; la imagen si hay 8b o frontera A en CI» cuesta dos frases y una variante corta Ilustrativa; el lado B obliga a completar tres ítems más (C2-14, C2-17, C2-18) dentro de la ruta estándar. |
| C2-14 | PROCEDE | Alcance mínimo: corregir `registrar-entorno.sh` para que no escriba `imagen=desconocida` y alinear §11.8 con lo que A.12 realmente hace (un paso de registro en A.12 con su salida); no un anexo nuevo con job de SBOM. |
| C2-15 | PROCEDE | Lado A: comprimir §9.2.4 a un bloque «Para 8b» bajo 600 palabras; es una rama condicional que hoy pesa tres veces lo que la respuesta estándar, y C2-16 y C2-21 entran dentro de ese presupuesto. |
| C2-16 | PROCEDE | Reemplazar un [no verificado] por el dato verificado (`builder-id=` lo escribe el invocador; vale sólo con el firmante) es de saldo casi nulo y sale del Anexo F; entra en una oración dentro del bloque de C2-15. |
| C2-17 | PROCEDE | Una línea: quién mueve el digest (Renovate o el workflow que publica) o [no verificado]; acotado a la rama imagen que deja C2-13. |
| C2-18 | PROCEDE | `packages: read` + `credentials` son dos líneas de YAML; sin ellas A.12 falla al copiarse con imagen privada (el default de GHCR). |
| C2-19 | PROCEDE | Una celda en «Qué no impide» y una mención en L1910; omitirlo vende como control un chequeo que otra fuente puede poner en verde. |
| C2-20 | PROCEDE | Cambiar «no impide nada» por «lo puede deshabilitar el administrador (o por delegación en GHES)» son pocas palabras y corrige una afirmación absoluta falsa. |
| C2-21 | PROCEDE | Sustituir en diagrama y tabla «BuildKit para procedencia» por (a)+(b)+(c) es de saldo neutro y quita una opción que no aplica a imagen única; condicionado al presupuesto de C2-15. |
| C2-22 | PROCEDE | Alcance mínimo: una nota «decide / lidera» en la matriz de §2.4 y llenar «Aplica»; no reestructurar la matriz. |
| C2-23 | PROCEDE | Reescribir cuatro filas que contradicen la decisión ya aplicada de C1-21 es saldo neutro; dejarlas mantiene una contradicción interna. |
| C2-24 | PROCEDE | Una advertencia de una línea con la alternativa que conserva `cli-plugins`; hoy el comando de digest de §8.5/E5-2 devuelve 16 líneas en vez del digest. |
| C2-25 | PROCEDE | Restituir una línea con su comentario; sin ella el hook falla en pre-commit < 4.4 con E1. |
| C2-26 | PROCEDE | Cambiar a `>> "$GITHUB_ENV"` y una aclaración breve; el `export` como paso propio no surte efecto y rompe la reproducibilidad que la sección promete. |
| C2-27 | PROCEDE | Alcance mínimo: copiar literal las salidas y marcar omisiones con `[…]`; una regla de recorte en §0.3 de una línea; sin chequeo mecánico nuevo. |
| C2-28 | PROCEDE | Agregar `,version=v1` y re-correr un script existente es barato; depender del default de BuildKit hace falsa la promesa SLSA v1 y contradice §9.2.4. |
| C2-29 | PROCEDE | Lado A: re-fechar con la fuente nueva en una oración y calificar por versión (≥ 3.15 vs 3.14 y anteriores); la recomendación no cambia y dejar como futuro algo ya publicado en la fecha de revisión es un error visible para cualquier lector. |
| C2-30 | PROCEDE | Reescribir por versión es de saldo casi nulo; hoy la frase es falsa para pnpm 9.7/10 con E1. |
| C2-31 | PROCEDE | Acotar a Linux/macOS y al fuente son pocas palabras; el cuantificador «siempre» tiene contraejemplo en la misma sección. |
| C2-32 | PROCEDE | Alcance mínimo: reponer §11.9.1 con el texto ya redactado en P-14 (E8-1), completar los seis puntos de §9.9.2 y reformular §0.2 a «respuesta esperada o criterio para evaluarla» en lugar de escribir criterios largos en §6.9.2 y §10.9.2. |
| C2-33 | PROCEDE | Acotado: una consigna integradora de tres líneas en §12 que remite a experimentos existentes y una fila en la ruta mínima; nada de experimentos nuevos. |
| C2-34 | PROCEDE | Corrección mecánica de trazas rotas (R-03, P-09), una línea que explique los IDs y retitular; trazas que no resuelven anulan la función del anexo. |
| C2-35 | PROCEDE | Alcance mínimo: dos entradas en el Anexo C con los sentidos de «registro» y «manifiesto» y unificar la forma de «registro del entorno»; no reescribir las 99 apariciones. |
| C2-36 | PROCEDE | Lado A atenuado: cada parche declara Δ palabras y el saldo del lote debe ser ≤ 0 (salvo voto explícito); la meta ≤ 48 000 queda orientativa [criterio], no motivo automático de rechazo, para no recortar evidencia que sostiene afirmaciones. |
| C2-37 | PROCEDE | Son los medios concretos para cumplir C2-36 (celdas largas a celda breve + lista, una regla por párrafo, bloques «Detalle de versión»); bajo riesgo porque no hay duplicados literales que perder. |
| C2-38 | PROCEDE | Simplificar §3.7 P2/P5 resta texto y la señal «Volver al mapa» es una línea; cierra a medias una decisión ya aprobada (C1-24). |
| C2-39 | PROCEDE | Un rótulo Ilustrativo (o [no verificado] con motivo); un YAML no ejecutado sin marca contradice la regla de evidencia de §0.3. |
| C2-40 | PROCEDE | Cambiar «cinco» por «cuatro» y corregir el control de cambios: costo nulo. |
