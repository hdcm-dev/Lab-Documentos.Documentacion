#!/usr/bin/env bash
# Barridos de 06-Plan §6 y §10.4 (+ RV-03, RV-12, RV-21, ids de bitácora, RD-PO-4)
G="${1:?raiz}"; cd "$G"
X=(--exclude-dir=bin --exclude-dir=obj -I)
GUIA=Dot-Net-Integration-AI-Layer-Guide.md
c(){ local d="$1" s="$2"; shift 2; local n; n=$(grep -rnE "${X[@]}" "$@" $s 2>/dev/null | wc -l); printf '%3d  %-58s %s\n' "$n" "$d" "$s"; }
echo "== §6 (P-26, P-44, P-12, P-38, P-39, P-31) =="
c 'npx -y' '.' -e 'npx -y'
c 'GuessNumber|EchoTool|GetWeather' '.' -e 'GuessNumber|EchoTool|GetWeather'
c '«mismo modelo» (guía)' "$GUIA" -e 'mismo modelo'
c '= true; (aprobación) en Examples/07' 'Examples/07-Agente-Con-Aprobacion' -e '(aprob|Aprob)[A-Za-z]* *= *true;'
c 'Comentario' '.' -e 'Comentario'
c 'mezcla sesiones' '.' -e 'mezcla sesiones'
c 'Evaluation en Demos/' 'Demos' -e 'Evaluation'
c 'Proveedor en Demos/' 'Demos' -e 'Proveedor'
c 'AyudaRag|ApprovalRequiredAIFunction en Demos/' 'Demos' -e 'AyudaRag|ApprovalRequiredAIFunction'
c '\bC[1-8]\b fuera de CASO-/CTRL- (guía)' "$GUIA" -e '(^|[^-A-Za-z0-9_])C[1-8]\b'
c '\bM[0-9]{1,2}\b (guía)' "$GUIA" -e '(^|[^-A-Za-z0-9_])M[0-9]{1,2}\b'
echo "== §10.4 =="
c 'pierde la sesión' '.' -e 'pierde la sesi[oó]n'
c 'falla al arrancar (con ValidateScopes)' '.' -e 'falla al arrancar'
c 'AyudaRag (Demos)' 'Demos' -e 'AyudaRag'
c 'IAlmacenDeRequisitos (Demos)' 'Demos' -e 'IAlmacenDeRequisitos'
c 'MapMcp (Demos)' 'Demos' -e 'MapMcp'
c 'McpServerTool (Demos)' 'Demos' -e 'McpServerTool'
c 'AprobacionPendiente (Demos)' 'Demos' -e 'AprobacionPendiente'
c 'aprobaciones/ (Demos)' 'Demos' -e 'aprobaciones/'
c 'UseDistributedCache|CacheConContador (Demos)' 'Demos' -e 'UseDistributedCache|CacheConContador'
c 'estado del servidor' '.' -e 'estado del servidor'
c 'si el cliente la expone' '.' -e 'si el cliente la expone'
c 'no se comparó punta a punta' '.' -e 'no se compar[oó] punta a punta'
c 'agentic workflow|flujo agéntico|flujo de trabajo' '.' -i -e 'agentic workflow|flujo ag[eé]ntico|flujo de trabajo'
c 'ia.cache.aciertos (sin prefijo)' '.' -e '(^|[^a-z])ia\.cache\.aciertos'
c 'ReadCacheStreamingAsync y no con ReadCacheAsync' '.' -e 'ReadCacheStreamingAsync`? y no con `?ReadCacheAsync'
c '[McpServerTool] (todo)' '.' -F -e '[McpServerTool]'
c '[C: marcas (guía)' "$GUIA" -F -e '[C:'
echo "== RV =="
c 'int.MaxValue|llama3.1' '.' -e 'int\.MaxValue|llama3\.1'
c 'MarkupString (Demos)' 'Demos' -e 'MarkupString'
c 'ApprovalRequiredAIFunction|AprobacionPendiente|aprobaciones/ (Demos) RV-21' 'Demos' -e 'ApprovalRequiredAIFunction|AprobacionPendiente|aprobaciones/'
c 'doble capa (guía; leer)' "$GUIA" -e 'doble capa'
c '«no vuelve a ejecutar las herramientas» (presente ≥1)' "$GUIA" -e 'no vuelve a ejecutar las herramientas'
echo "== ids de bitácora en la guía (RV-08) =="
c 'P-NN|P2-NN' "$GUIA" -e '(^|[^A-Za-z0-9])P2?-[0-9]{2}\b'
c 'MI-NN' "$GUIA" -e '\bMI-[0-9]+'
c 'C1-NN' "$GUIA" -e '\bC[0-9]-[0-9]+'
c 'R-C, EA-, PC-, RV-, RD-PO, BIT-, REED, S-NN, N0..N6, DC-, SUP-' "$GUIA" -e '\bR-C[0-9]+|\bEA-?[0-9]+|\bPC-[0-9]+|\bRV-[0-9]+|RD-PO|BIT-16|REED-|\bS-[0-9]{2}\b|\bN[0-6]b?\b|\bDC-[0-9]+|\bSUP-[0-9]+|\bELV-|\bAH-[0-9]+|\bMD-[0-9]|\bPR-[0-9]+|\bR-LLM-[0-9]'
c 'Bitácora/Bitacoras/mesa/presidencia/jurado' "$GUIA" -i -e 'bit[aá]cora|presidencia|jurado|\bla mesa\b|n[uú]cleo N'
c 'ids en Examples/Demos (P-,MI-,C1-,PC-,RV-)' 'Examples Demos' -e '(^|[^A-Za-z0-9])(P2?-[0-9]{2}|MI-[0-9]+|C[0-9]-[0-9]+|PC-[0-9]+|RV-[0-9]+|R-C[0-9]+|BIT-16|REED-16)\b'
echo "== RD-PO-4 dominios ajenos =="
c 'reclamo|pozo|semáforo|Movie|línea 1|ReportarIncidente' '.' -i -e 'reclamo|pozo|sem[aá]foro roto|\bMovie\b|l[ií]nea 1\b|ReportarIncidente|ConsultarEstado|GetEstadoLinea'
