# Voto del juez de riesgo · ciclo 2 (relectura integral)

Fecha: 2026-10-28. Función: ¿hay riesgo o irreversibilidad? Veto sólo ante una corrección irreversible con severidad ≤ S3.

## Verificación previa

- La guía, Examples/ y Demos/ están limpios en git (`git status` en 0 líneas, HEAD `0989a15`). Toda corrección en el lugar se revierte con git. Ninguna opción es irreversible. Por eso no hay **ningún veto**.
- Lo único que no tiene vuelta es publicar: commit y push a un repo público. El riesgo real de esta corrida es de exposición (R-PRIV) y de regresión, no de pérdida. Lo cuido así:
  - priorizo cerrar las fugas de host:puerto y la exposición por red (C2-18, C2-41, C2-42);
  - cambio código sólo con prueba de Cableado/ en verde, compilado con el recurso «build» sobre copias;
  - en la guía, la renumeración (C2-04) va al final y se verifica por script.
- Código comprobado: `appsettings.json` de la demo trae `"AllowedHosts": "*"`. `EnableSensitiveData` depende del entorno, en 09 y en la demo.

## Votos

| Ítem | Opción | Fundamento de riesgo |
|---|---|---|
| C2-01 | D | Es un reemplazo textual y se revierte. D conserva el matiz sin cargar el nombre canónico. |
| C2-02 | D | Formato único, que se verifica por grep. Pasar los `####` a negrita saca anclas del índice: hay que revisar el índice después. |
| C2-03 | A | Sólo agrega líneas. Riesgo nulo. |
| C2-04 | C | Renumerar sólo §7 acota el radio. Mover bloques de §4 y §6 arriesga 75 anclas. Va al final, con un chequeo de anclas rotas por script, y se revierte con git. |
| C2-05 | C | La tabla reducida no afirma nada sobre cajas no tratadas. La completa obliga a sostener 21 afirmaciones nuevas, cada una con riesgo de inventar. |
| C2-06 | A | Sólo agrega texto, sin riesgo técnico. |
| C2-07 | A | Un enlace interno. La imagen incrustada pide repasar R-PRIV en la captura. |
| C2-08 | A | Corrige atribuciones falsas. Es el riesgo de evidencia más alto de la lista. |
| C2-09 | A | Conserva las atribuciones únicas, así que no se pierde evidencia. C borraría la única mención del modelo de humo. |
| C2-10 | A | Usa cifras que ya están en E.4. No obliga a tocar el anexo. |
| C2-11 | A | Usa la operación medida. C deja una cifra sin fuente. |
| C2-12 | A | Alinea la guía con E.4. Sumar la fila O3 es agregado, sin riesgo. |
| C2-14 | A | Edición bibliográfica. Las versiones arXiv se toman de la API con fecha. |
| C2-15 | A | Corrige el signo opuesto. S4 sin riesgo. |
| C2-16 | A | Sólo texto. C toca categorías en cuatro proyectos y puede dejar pruebas fuera del filtro sin aviso. |
| C2-17 | A | Evita salidas con dueño root en el árbol del repo, que después ensucian el commit. Ya está medido: 23/23 en verde. |
| C2-18 | A | Es fuga de host:puerto en un repo público. Riesgo de exposición si se publica. Sólo texto (C) deja una frase falsa. El cambio en el helper se revierte y lleva prueba. |
| C2-19 | A | Sólo texto, conservador. Clasificar en código (C) agrega lógica sin medir. |
| C2-20 | C | Documentar es reversible y no rompe el R-LLM ya corrido. Unificar en código invalida comandos registrados en la bitácora. |
| C2-21 | A | Es un cambio de una línea, local y verificable en consola. |
| C2-22 | A | Las unidades y «vCPU» corrigen un error. Abreviar reduce texto. Los textos nuevos ya nacen con el rótulo abreviado. |
| C2-23 | A | Un conteo verificable. |
| C2-24 | A | Cambio terminológico, verificable por grep. |
| C2-25 | A | Corrige un ruteo equivocado del árbol de decisión. |
| C2-26 | A | Sólo agrega definiciones. |
| C2-27 | A | Cambia la ruta de lectura, sin riesgo. |
| C2-28 | A | Arregla la medida y fija topes orientativos, no vinculantes, así que no fuerza a recortar evidencia. Los recortes respetan la regla de C2-09 A. |
| C2-29 | A | Remitir no pierde contenido, porque la tabla canónica queda. Conserva el commit y la ruta de la prueba. |
| C2-30 | C | Sólo las réplicas exactas: no se pierde criterio formativo. El recorte amplio arriesga vaciar preguntas guía. |
| C2-31 | A | La guía declararía como juez fiable algo que el laboratorio refutó: eso es riesgo de evidencia. |
| C2-32 | A | Un verde que no mide es el riesgo de falso cierre más serio. Lleva invariante y prueba. |
| C2-33 | A | Saca el fallo por azar y conserva las aserciones de existencia legítimas. C debilita la cobertura. |
| C2-34 | A | Una sola regla elimina resultados distintos para el mismo caso. |
| C2-35 | A | Aclara la unidad. Sin riesgo. |
| C2-36 | A | Aclaraciones. Sin riesgo. |
| C2-37 | C | Corrige el error y conserva el diagrama didáctico. Borrar (A) pierde contenido. Los dos se revierten. |
| C2-38 | A | Saca una afirmación de costo contradicha por la medida. La cifra va con el rótulo de C2-22. |
| C2-39 | A | Riesgo de seguridad: un dato inventado entra sin marca. El cambio de código lleva prueba y se revierte. |
| C2-40 | A | Corrige un ruteo hacia MAF sin respaldo. Es texto. |
| C2-41 | A | `-p 127.0.0.1` y la viñeta medida reducen la exposición. D (`AllowedHosts`) es código sin medir en la demo. Queda como mejora, no ahora. |
| C2-42 | A | La frase es falsa y tiene impacto de exposición de red. |
| C2-43 | A | Lo respalda el XML del paquete. Es texto. |
| C2-44 | A | La frase dice lo contrario del registro. |
| C2-45 | A | Lote S4 de forma, reversible. |
| C2-46 | A | Cifras que el registro sostiene. |
| C2-47 | A | Cierra un vector de inyección en el rol System. Lleva prueba y se revierte. |
| C2-48 | A | Cita fiel a la fuente. |
| C2-49 | A | Saca una atribución falsa. |
| C2-50 | A | Error técnico con fuente fechada. |
| C2-51 | C | Nombrar el límite no tiene riesgo. PooledConnectionLifetime cambia el cableado de dos proyectos sin medida propia. |
| C2-52 | C | Mover herramientas en la demo (A) es la mayor cirugía de código del ciclo, con re-verificación de CTRL-06 y del modelo. Como deuda declarada, la contradicción no queda oculta y no se arriesga regresión. |
| C2-53 | C | Una oración. Cambiar el motor (A) puede hacer saltar rojos nuevos en la demo, encadenados con C2-52. |
| C2-54 | C | Mermaid y oración, sin mover registro. Coherente con C2-52 C. |
| C2-55 | A | Declararlo no rompe nada. Mover (C) toca rutas de snippets. |
| C2-56 | A | Párrafo. Sin riesgo. |
| C2-57 | A | Acota una generalización sin respaldo. |
| C2-58 | A | Una oración. Las corridas extra (C) consumen turnos del modelo. |
| C2-59 | C | Una oración. Una prueba nueva con modelo pide corridas R-LLM y recurso. |
| C2-60 | A | Corrige la fragilidad sin primitivas nuevas de concurrencia. |
| C2-61 | A | Moverlo rompe las pruebas, según el propio ítem. |
| C2-62 | A | Párrafo. Sin riesgo. |
| C2-63 | A | Sólo texto, en ítems S4. |
| C2-64 | A | Completar campos. Sin riesgo. |
| C2-65 | A | Forma única. Si se hace con sed, revisar el diff. |
| C2-66 | A | Lo recortado ya está en §0.4, §0.5 y D.2. |
| C2-67 | C | Conserva la regla 3 de E.5, que es operativa. Los anexos deben poder leerse solos. |
| C2-68 | C | Las preguntas guía conservan su tono. Bajo riesgo. |

## Condiciones de aplicación (riesgo)

1. Antes de terminar, barrer R-PRIV sobre la guía, Examples/ y Demos/, incluidas las salidas nuevas de C2-18.
2. Volver a compilar y correr Cableado/ en cada proyecto con código tocado (C2-18, C2-21, C2-32, C2-33, C2-39, C2-47, C2-60). No dejar bin/, obj/ ni *.db en el árbol.
3. C2-04 va al final, seguido de un chequeo de anclas rotas.
4. Sin commit ni push.
