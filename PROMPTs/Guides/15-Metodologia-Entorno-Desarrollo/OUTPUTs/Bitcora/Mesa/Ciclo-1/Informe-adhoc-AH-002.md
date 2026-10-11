# Informe AH-002 — Cadena de suministro y gobierno de la CI (ciclo 1)

Especialista ad hoc: integridad, procedencia y compuertas de plataforma. Revisión a ciegas del borrador integrado (`Metodologia-Entorno-Desarrollo-Guide.md`, 3060 líneas). Fuentes consultadas el 2026-10-07.

Pregunta: ¿cada garantía que la guía atribuye a un mecanismo de integridad, procedencia o compuerta de plataforma es la que su especificación o plataforma realmente otorga, y está dicho lo que NO protege?

## Hallazgos

### adhoc-AH-002-01 — «L1 de inmediato» con una procedencia que no cumple L1 (S2, E4 + E1)

- Ubicación: §9.2.4 L1484, L1496; §9.6 L1570.
- Ancla: L1570 «L1 de inmediato (BuildKit o el runner de GitLab ya la generan)»; L1484 «`builder.id` **vacío**, porque una build local no tiene identidad de plataforma»; salida E6-5 (`N6-…/salidas/e5-procedencia-slsa-firmada.txt`, línea 17): `runDetails.builder={'id': ''}`.
- Evidencia: SLSA v1.2 Build provenance (https://slsa.dev/spec/v1.2/build-provenance, 2026-10-07): `runDetails.builder.id` es REQUIRED para Build L1 y «intended to be the sole determiner of the SLSA Build level»; «Consumers MUST accept only specific signer-builder pairs». Build requirements (https://slsa.dev/spec/v1.2/build-requirements): L1 exige que la plataforma de build genere la procedencia.
- Problema: la propia guía cita a `builder.id` como único determinante del nivel y su experimento lo deja vacío, pero recomienda declarar L1 «de inmediato» con BuildKit. Una procedencia sin `builder.id` no es una procedencia L1 conforme y no es verificable por ningún consumidor (no hay par firmante-builder que aceptar). L1496 pide «declarar el nivel alcanzado sin inflarlo» pero no dice cuál es.
- Dirección: decir explícitamente que la procedencia de BuildKit tal como sale en E6-5 **no alcanza L1** hasta que `builder.id` identifique la plataforma de CI (y que eso lo documente el equipo, como pide la especificación); que la ruta «BuildKit + cosign con clave propia» es, a lo sumo, L1 con firma de un inquilino; y que el consumidor necesita una política que fije el par firmante (clave) / `builder.id`. Si se propone cómo completar `builder.id` en BuildKit, verificarlo en E1 antes de afirmarlo.

### adhoc-AH-002-02 — «Rama protegida con chequeo requerido impide el merge» sin decir qué no impide (S2, E4)

- Ubicación: §10.2.7 L1716 y tabla L1722–L1727; A.12 L2502–L2530; A.14.
- Ancla: tabla «Rama protegida con chequeo requerido (si el plan la ofrece) | El merge o el push | [B177][B186]»; A.12 ejecuta `tools/ci/compuerta.sh` desde el checkout del PR.
- Evidencia: GitHub, About protected branches (2026-10-07): «Required status checks must have a `successful`, `skipped`, or `neutral` status»; «By default, the restrictions … don't apply to people with admin permissions»; la revisión de dueños y «the most recent reviewable push must be approved by someone other than the person who pushed it» son opciones aparte. Events that trigger workflows (2026-10-07): `pull_request` corre «in the context of the merge commit» (`GITHUB_SHA` = merge commit del PR), a diferencia de `pull_request_target`. GitLab, Auto-merge (Tier Free, Premium, Ultimate): «Pipelines must succeed. This setting also prevents merge requests from merging if there is no pipeline».
- Problema: (a) el chequeo requerido lo produce código que el mismo PR puede cambiar: un PR que edita `compuerta.sh` o el workflow para que salga 0 pasa el chequeo; sólo lo cierra la revisión obligatoria de dueños sobre `/.github/` y `/tools/ci/` más la aprobación del último push, y eso depende del plan (A.14 lo pregunta, la tabla de §10.2.7 no lo condiciona). (b) Un job salteado (`skipped`) satisface el chequeo. (c) El bypass de administradores es el comportamiento por defecto (se dice en §10.2.8, no en la tabla de «qué impide»). (d) Para el caso (repo privado de una **organización**), GitHub Pro no aplica: es plan de cuentas personales; el mínimo es Team. (e) Falta la vía que sí impide en GitLab Free: rama protegida sin push directo + «Pipelines must succeed».
- Dirección: agregar a la fila una columna o nota «qué no impide» con (a)–(c); condicionar «impide» a: revisión obligatoria de dueños sobre los archivos de la compuerta + aprobación del último push + administradores incluidos; corregir «Pro» por «Team» para organizaciones; sumar la fila de GitLab Free con «Pipelines must succeed».

### adhoc-AH-002-03 — Actualización de digests por Dependabot: la guía se contradice y el anexo omite el ecosistema (S2, E4)

- Ubicación: §8.2.2 L1221; A.13 L2535–L2567; Anexo F L3044.
- Ancla: §8.2.2 «propone mitigarlo con Docker Scout o con Dependabot, que abre PR con el digest nuevo [B113]»; A.13 «que Dependabot `docker` actualice un `FROM …@sha256` no está verificado»; Anexo F «si Dependabot `docker` actualiza un `FROM …@sha256`».
- Evidencia: Docker Docs, Building best practices (https://docs.docker.com/build/building/best-practices/, 2026-10-07): «Dependabot raises pull requests to update your base image tags and digests on a schedule». El `dependabot.yml` del laboratorio (`Examples/N7-compuertas-y-gobierno/06-actualizacion-automatica/dependabot.yml`) sí incluye `docker` y `devcontainers`; el de A.13 no.
- Problema: la guía afirma con fuente en §8 lo que en A.13 y el Anexo F rotula como no verificado. Más grave: §8.2.2 dice que fijar digests sin el punto 2 (actualización como PR) «congeló vulnerabilidades», y el `dependabot.yml` que el lector copia de A.13 no tiene ningún ecosistema que proponga digests.
- Dirección: unificar el rótulo («documentado por Docker [B113]; comportamiento no observado en el laboratorio»); agregar `docker` (con el directorio del `Dockerfile` de CI) a A.13, alineado al laboratorio, y mantener la advertencia de que `devcontainers` no aplica a repos privados [B107]. Verificar también en la doc de GitHub (no sólo la de Docker) antes de subir el nivel.

### adhoc-AH-002-04 — Firma: falta la vía sin clave y lo que la firma con clave no protege (S3, E4)

- Ubicación: §9.2.4 L1486, L1496; §9.5 L1553–L1557.
- Ancla: «BuildKit + cosign en la CI con la clave fuera del alcance de los pasos de build en lo posible»; `cosign attest-blob … --key cosign.key … --tlog-upload=false`; `verify-blob-attestation … # falla si cambia 1 byte o el predicado`.
- Evidencia: Sigstore, Signing overview (https://docs.sigstore.dev/cosign/signing/overview/, 2026-10-07): firma sin clave con tokens OIDC de emisores admitidos (`--identity-token`, audiencia `sigstore`); los eventos se suben a Rekor «so that the events are publicly auditable»; instancia propia como alternativa privada. GitHub, Artifact attestations (2026-10-07): repos privados usan «GitHub's Sigstore instance … does not have a transparency log». SLSA v1.2: consumidores aceptan sólo pares firmante-builder.
- Problema: (a) «dos caminos honestos» omite cosign sin clave con el `id-token` de la CI, disponible en cualquier plan, que ata la firma a la identidad del workflow en vez de a un archivo de clave; su costo para un repo **privado** es que la identidad (organización, repo, ruta del workflow) queda en el log público de Rekor, cosa que hay que decir. (b) Con clave en secreto de la CI, cualquier paso del job que la reciba puede firmar cualquier cosa; «en lo posible» no dice cómo (job separado, entorno con aprobación, sin código del PR). (c) `verify-blob-attestation` comprueba firma, `subject` y tipo; **no** comprueba `builder.id`, origen ni parámetros: un predicado falso firmado con la clave legítima verifica `Verified OK`. El comentario «falla si … el predicado» sólo vale para ediciones posteriores a la firma.
- Dirección: agregar la vía sin clave con su costo de privacidad; concretar (b) como regla; aclarar en el ejemplo que la verificación del predicado (builder, repo, commit esperados, [B10]) es un paso aparte, con política (p. ej. `--policy` de cosign, a verificar en E1 antes de afirmarlo).

### adhoc-AH-002-05 — Mapeo de fuentes: los huecos sólo se dicen para NuGet (S3, E4)

- Ubicación: §7.3 L1076; §7.6 P4 L1140; §11 L1915.
- Ancla: L1140 «El mapeo de fuentes ataca la **confusión de dependencias**, con sus huecos (E4-3)»; tabla L1076 «`.npmrc` del proyecto, registros por *scope*» y pip «`--index-url`».
- Evidencia: npm Docs, scope (https://docs.npmjs.com/cli/v11/using-npm/scope, 2026-10-07): «Scopes can be associated with a separate registry»; «a scope only ever points to one registry» — la asociación se define por scope, los paquetes sin scope van al registro por defecto.
- Problema: E4-3 mide sólo NuGet. En npm el mapeo por scope protege sólo a los paquetes internos que **tienen** scope (y cuyo scope controla la organización en el registro público); un paquete interno sin scope sigue expuesto a la confusión. En pip la protección la da `--index-url` único; agregar `--extra-index-url` reabre el ataque. La guía presenta los tres mecanismos como equivalentes.
- Dirección: una línea por ecosistema con su hueco: npm (paquetes internos sin scope, scope no reservado en el registro público), pip (`--extra-index-url`), uv (`explicit = true` sólo protege los paquetes asignados a ese índice). Y aclarar que, una vez bloqueado, el `resolved`/hash del lock fija el origen: el riesgo de confusión está en el momento de bloquear o actualizar.

## Revisado y bien

1. Tabla de niveles SLSA Build (L1478–L1482) y la regla de no declarar L2 al firmar con clave propia (L1486, L1570 última oración): coinciden con SLSA v1.2 Build requirements («The provenance MUST be generated by the control plane … and not by a tenant» para L2; secretos inaccesibles a pasos del usuario para L3).
2. Atestaciones de GitHub (tabla de L1490): «by itself provides SLSA v1.0 Build Level 2», L3 con reusable workflows, y repos privados con instancia Sigstore de GitHub sin log de transparencia; restricción por plan coherente con la doc.
3. Acciones por SHA y bots (L1677, L1702): «the only way to use an action as an immutable release», Dependabot sin alertas para acciones fijadas por SHA; enfriamiento por defecto de 3 días (sin aplicar a actualizaciones de seguridad) y límite de cinco PR de versión: verificados en docs.github.com.

## Solicitudes de convocatoria

Ninguna.
