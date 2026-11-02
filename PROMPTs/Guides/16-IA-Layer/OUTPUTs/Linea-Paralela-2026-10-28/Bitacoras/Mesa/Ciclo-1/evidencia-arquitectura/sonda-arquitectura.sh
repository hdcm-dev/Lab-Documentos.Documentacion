#!/bin/sh
# Sonda de arquitectura del especialista ARQUIT (ciclo 1, 2026-10-28). Sólo lectura: grep sobre el caso base y la evidencia EA-2/EA-3.
W="${WORKSPACE:?raíz del workspace}"
SRC=$W/LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor/src/MovilidadUrbana.ApiWeb
EA=$W/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/OUTPUTs/Bitacoras/Integracion-Evidencia/A-arquitectura/exp-capas
echo "== S1 commit del caso base"; git -C "$SRC" log -1 --format='%h %ci'
echo "== S2 carpetas de ApiWeb (lo que MI-05 copia: Domain, Application, Controllers, Sessions)"; ls -1 "$SRC"
echo "== S3 dependencias de Controllers/ fuera de Domain/Application"; grep -n '^using MovilidadUrbana' "$SRC"/Controllers/*.cs
echo "== S4 LocalidadesController inyecta el repositorio (saltea el caso de uso)"; grep -n 'ILocalidadRepository\|repository\.' "$SRC"/Controllers/LocalidadesController.cs
echo "== S5 API pública de LocalidadService (¿hay validar sin guardar?)"; grep -n 'public' "$SRC"/Application/Localidades/LocalidadService.cs
echo "== S6 ProvinciaValida en Domain (¿controla catálogo?)"; grep -n 'ProvinciaValida' "$SRC"/Domain/Rules/LocalidadRules.cs
echo "== S7 puertos de IA de EA-2 (forma del contrato)"; grep -n 'Task<' "$EA"/Nuevo/Application/Abstractions/PuertosDeIA.cs
echo "== S8 carpetas que mira la prueba de arquitectura EA-3"; grep -n 'for d in' "$EA"/verificar-capas.sh
echo "== S9 paquetes que busca EA-3"; grep -n 'grep -rlE' "$EA"/verificar-capas.sh
echo "== S10 el adaptador de la vía B depende del servicio concreto de Application"; grep -n 'LocalidadService\|using MovilidadUrbana' "$EA"/Nuevo/Infrastructure/AI/Adaptadores.cs
