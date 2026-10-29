# 04 — PR #25: guarda CPA, merge y corrida en el runner

PR: https://github.com/hdcm-dev/Lab-Documentos/pull/25 · cabeza 6839258adee7a202b2c160b605db9cfc01ee7c65 · merge fe10086f2b083f6cfe227da49174d204c1b0e008

## Guarda G1–G4 (techo 7200 s, intervalo 30 s)
```text
19:18:26 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=3 fallidas=0
19:18:59 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=3 fallidas=0
19:19:32 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=3 fallidas=0
19:20:05 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=2 fallidas=0
19:20:38 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=2 fallidas=0
19:21:11 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=2 fallidas=0
19:21:44 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=2 fallidas=0
19:22:17 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=2 fallidas=0
19:22:51 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=1 fallidas=0
19:23:24 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=1 fallidas=0
19:23:56 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=1 fallidas=0
19:24:29 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=1 fallidas=0
19:25:02 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=1 fallidas=0
19:25:35 state=open head=6839258 mergeable=true mstate=blocked runs=3 en-curso=1 fallidas=0
19:26:08 state=open head=6839258 mergeable=true mstate=clean runs=3 en-curso=0 fallidas=0
GUARDA OK en 465 s
RUN mini-demo-movilidad 40593744997 success 2026-10-27T22:18:05Z 2026-10-27T22:19:43Z
RUN docs-guard 40593745133 success 2026-10-27T22:18:05Z 2026-10-27T22:22:25Z
RUN framework-concept-demo 40593745265 success 2026-10-27T22:18:05Z 2026-10-27T22:25:48Z
JOB mini-demo success runner=self-hosted,i7infra-dev
JOB docs-guard success runner=self-hosted,i7infra-dev
JOB alcance success runner=self-hosted,i7infra-dev
JOB fw-ok success runner=self-hosted,i7infra-dev
JOB compuerta skipped runner=self-hosted,i7infra-dev
JOB apk skipped runner=self-hosted,i7infra-dev
MERGE fe10086f2b083f6cfe227da49174d204c1b0e008
RAMA exp0002/e1-u4f-guia-obsoleta -> 404
FIN
```

## Job docs-guard (run 40593745133), líneas de resumen
```text
== herramientas: lychee 0.18.1, mermaid (lockfile), markdownlint-cli2 0.17.2
== PR-1 enlaces: lychee --offline --include-fragments y relativos fuera del repo (Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion AGENTS.md)
== PR-1 fuera-del-repo: verde (errores=0 avisos=0)
== PR-2 esquema (Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion)
== PR-2 esquema: verde (errores=0 avisos=0) archivos-con-frontmatter=41 sin-frontmatter-fuera-del-cuerpo=1
== PR-3 anti-inyección (Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion AGENTS.md)
== PR-3 anti-inyeccion: verde (errores=0 avisos=28) AI-1=0 AI-2=0 AI-3=0 AI-4=28 AI-5=0
== PR-4 estructura: markdownlint-cli2 y mermaid (Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion AGENTS.md)
== PR-4 mermaid: verde (bloques=28 invalidos=0)
== PR-5 trazas (Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion)
== PR-5 traces-resolve: verde (errores=0 avisos=9) trazas=121 resueltas=112 anclas=0 anclas-resueltas=0
== PR-6 contrato (Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion)
== PR-6 contratos: verde (errores=0 avisos=0) contratos=1
== PR-7 fijadas y reflint (Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion)
== PR-7 fijadas: verde (errores=0 avisos=0) piezas=0
== PR-7 reflint: verde (errores=0 avisos=0) referencias=51
== PR-7 url-fecha: verde (errores=0 avisos=33) documentos-que-bloquean=41
== autoprueba: pares rojo/verde por control (G-c) y fixture permanente AK-7
  ok    PR-1 lychee                  rojo (rc=2)
  ok    PR-1 lychee                  verde (rc=0)
  ok    PR-1 fuera                   rojo (rc=1)
  ok    PR-1 fuera                   verde (rc=0)
  ok    PR-2 esquema                 rojo (rc=1)
  ok    PR-2 esquema                 verde (rc=0)
  ok    PR-5 trazas                  rojo (rc=1)
  ok    PR-5 trazas                  verde (rc=0)
  ok    PR-7 fijadas                 rojo (rc=1)
  ok    PR-7 fijadas                 verde (rc=0)
  ok    PR-7 reflint                 rojo (rc=1)
  ok    PR-7 reflint                 verde (rc=0)
  ok    PR-7 url-fecha               rojo (rc=1)
  ok    PR-7 url-fecha               verde (rc=0)
  ok    PR-5 anclas                  rojo (rc=1)
  ok    PR-7 url-fecha obsoleto      verde (rc=0)
  ok    PR-5 anclas                  verde (rc=0)
  ok    PR-3 AI-1                    rojo (rc=1)
  ok    PR-3 AI-2                    rojo (rc=1)
  ok    PR-3 AI-4                    rojo (rc=1)
  ok    PR-3 AI-5                    rojo (rc=1)
  ok    PR-3 AI (página limpia)     verde (rc=0)
  ok    PR-3 AI-3 avisa              verde (rc=0)
  ok    PR-3 AI-4 avisa en anexo     verde (rc=0)
  ok    PR-4 markdownlint            rojo (rc=1)
  ok    PR-4 markdownlint            verde (rc=0)
  ok    PR-4 mermaid                 rojo (rc=1)
  ok    PR-4 mermaid                 verde (rc=0)
  ok    PR-6 contrato                rojo (rc=1)
  ok    PR-6 contrato                verde (rc=0)
  ok    AK-7 fixture permanente      rojo (rc=1; AI-1..AI-5 detectados)
== autoprueba: verde
== avisos: url-fecha y cita-linea (Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion)
== avisos url-fecha y cita-linea: verde (errores=0 avisos=11)
##[group]Run FALLA=0
[36;1mFALLA=0[0m
[36;1m  if [ "$r" != "success" ]; then FALLA=1; echo "::error::docs-guard: el grupo $g dio $r"; fi[0m
[36;1mif [ "$FALLA" -ne 0 ]; then echo "== docs-guard: ROJO"; exit 1; fi[0m
[36;1mecho "== docs-guard: verde"[0m
== docs-guard: verde
```

Corridas sobre el commit de merge: 0 (los workflows corren en pull_request; igual que en U4d).
