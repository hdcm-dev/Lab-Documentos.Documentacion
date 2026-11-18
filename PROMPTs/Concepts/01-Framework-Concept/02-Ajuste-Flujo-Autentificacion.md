```
Dice que una app nativa no debe mostrar la página de login dentro de su propio WebView (embedded user-agent). Tiene que usar un agente externo, el navegador del sistema.
```

claro!, pero una apps normalmente ofrece su pantalla de login - que sea una pagina del contenido dinamico o no - ahi es un tema a debatir -

por otro lado que flujo de autenticación vamos a usar ? - supone que se loguea una vez contra el sistema y luego los proximos bloqueos son usando la seguridad del movil.

y acá pone atención porque va en como vamos a diseñar las aplicaciones.

la mayoria de las aplicaciones loguean con su pagina/pantalla dentro de la aplicación y gran parte de esas al bloquearse lanzan de vuelta esta pagina - ahora , hay otras, que cuando se bloquean lanzan la seguridad del movil a no ser que cerres la sessión.

que  es lo que pasa aquí? - tenemos un contenido dinámico , aquí se descarga y se ejecuta, y ahí! - salta la ventana de login , - nos vamos , perdemos internet , se bloquea, - y ahi el desbloqueo de la apps es por medio de la seguridad del telefono - se desbloquea y podemos operar la apps sin internet .

si dependemos de la pagina de login - sea porque no tenemos este flujo de autentificación que te menciono o bien porque el telefono no tiene mecanismo de bloqueo configurado y deja irremediablemente a que la apps quede condicionada a que desbloquee contra el servidor.

con esto  -si fuese una aplicación de inspección, encuestas, o bien relevamientos, no hay internet - el desbloqueo es con el patron - para ejemplificar - y sigue sin conexión algun. 


Por otro lado, de usar autentificación externa, no se si lanzar el navegador dentro de un movil, creo que hay otros mecanismos propios del mismo movil, el sistema del movil maneja las cuentas o bien almacena cuentas de tercero


