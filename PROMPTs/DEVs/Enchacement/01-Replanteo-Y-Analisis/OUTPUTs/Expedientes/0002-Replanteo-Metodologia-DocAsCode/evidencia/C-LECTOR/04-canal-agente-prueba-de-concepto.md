# Ensayo E-04 — canales para agentes de la prueba de concepto, sin sesión y con sesión

Fecha: 2026-10-26. Fuente: copia de `/LAB/Lab-Documentos/Lab-Documentos/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/Prueba-Ayuda-Por-Rol/Web/` (sin `bin/` ni `obj/`) en `$WORK/poc-web`, fuera del workspace, borrada al terminar. Contenedor con nombre `clector-poc`, eliminado con `docker rm -f` al terminar.

## Comandos

```bash
rsync -a --exclude bin --exclude obj <Examples>/Prueba-Ayuda-Por-Rol/Web/ $WORK/poc-web/
docker run -d --name clector-poc -u $(id -u):$(id -g) -e HOME=/tmp \
  -e ASPNETCORE_URLS=http://0.0.0.0:5190 -e ASPNETCORE_ENVIRONMENT=Production \
  -p 127.0.0.1:5291:5190 -v $WORK/poc-web:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 dotnet run --no-launch-profile
for p in /ayuda/llms.txt /llms.txt /ayuda /ayuda/comun/ingresar.md; do
  curl -s -o /dev/null -w '%{http_code} loc=%{redirect_url}' http://127.0.0.1:5291$p; done
curl -s -c cj.txt -o /dev/null http://127.0.0.1:5291/entrar/Student
curl -s -b cj.txt -D - http://127.0.0.1:5291/ayuda/llms.txt
docker rm -f clector-poc
```

## Salida (recortada)

```text
Catálogo de ayuda: 9 páginas, validador con 0 fallas          (log de arranque)

Sin sesión
/ayuda/llms.txt          -> 302  loc=http://127.0.0.1:5291/ingresar?ReturnUrl=%2Fayuda%2Fllms.txt
/llms.txt                -> 404
/ayuda                   -> 302  loc=http://127.0.0.1:5291/ingresar?ReturnUrl=%2Fayuda
/ayuda/comun/ingresar.md -> 302  loc=http://127.0.0.1:5291/ingresar?ReturnUrl=%2Fayuda%2Fcomun%2Fingresar.md

Con sesión de alumno (/entrar/Student)
HTTP/1.1 200 OK
Content-Type: text/plain; charset=utf-8

# Ayuda de la Fábrica de Geometría — Student

- [Ingresar al laboratorio](/ayuda/comun/ingresar.md): Entrar con tu correo y tu contraseña.
- [Cambiar la contraseña](/ayuda/comun/cambiar-la-contrasena.md): Cuándo el laboratorio te la pide y cómo se cambia.
- [Enviar un trabajo](/ayuda/alumno/enviar-un-trabajo.md): Pegar la salida de tu programa y leer las observaciones.
- [Mis trabajos](/ayuda/alumno/consultar-mis-trabajos.md): Tus envíos, su estado y el desenlace de la revisión.
```

## Lectura

- Un agente sin sesión recibe una redirección a una página HTML de ingreso, no un `401` (`Web/Program.cs:41` prevé `401`). Reproduce lo que asentó `R02` §6.8.
- No hay `/llms.txt` en la raíz del sitio: el índice vive en `/ayuda/llms.txt`.
- Con sesión, el índice cumple la parte obligatoria de la propuesta (una H1) y no trae resumen ni secciones H2 (coincide con `R02` §6.9).
- La guía llama a `llms.txt` «Convención … (adoptada por varios generadores)» (`Sistema-Documentador-Tecnico-Guide.md:161`).
