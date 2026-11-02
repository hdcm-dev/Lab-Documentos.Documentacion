#!/usr/bin/env bash
# Demo en Development, sin servidor de modelo: ¿la consola muestra la URL del servidor al primer pedido?
W=$W
docker run -d --name cat-op-c2-demo --network none -v <volumen-nuget>:/root/.nuget/packages -v $W/demo:/work -w /work \
  -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_URLS=http://+:8080 -e OLLAMA_ENDPOINT=http://servidor-de-prueba:11434 \
  mcr.microsoft.com/dotnet/sdk:10.0 dotnet run --project src/MovilidadUrbana.Asistente --no-build --no-launch-profile >/dev/null
for i in $(seq 1 40); do docker logs cat-op-c2-demo 2>&1 | grep -q 'Application started' && break; sleep 2; done
docker exec cat-op-c2-demo curl -s -m 60 -H "X-Sesion-Id: prueba" -H "Content-Type: application/json" -d '{"texto":"¿Qué medio usa más la gente?"}' http://localhost:8080/api/v1/asistente > $W/02-respuesta.txt 2>&1
sleep 2; docker logs cat-op-c2-demo > $W/02-consola-development.txt 2>&1
docker rm -f cat-op-c2-demo >/dev/null
