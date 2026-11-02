# Colmenar

Descripción del producto, escrita por el dueño del producto antes de empezar. Dice hechos, no cómo se van a
organizar los textos del proyecto.

## 1. Propósito

Una cooperativa de productores de miel pierde colmenas por robo, por mortandad que nadie registra a tiempo y por
tambores de miel que llegan a la planta sin saber de qué apiario salieron. Colmenar es una app .NET MAUI para
registrar cada visita a un apiario, cada traslado de colmenas (trashumancia) y cada tambor entregado, y para que la
cooperativa vea el estado de todos los apiarios en un panel. La app se financia con un programa provincial de
desarrollo apícola, y una escuela agrotécnica la usa para enseñar programación.

## 2. Personas y perfiles

| Perfil | Qué hace en la app | Qué no puede hacer |
| --- | --- | --- |
| Productor | Da de alta sus apiarios, ve sus colmenas, sus traslados y sus tambores | Ver apiarios de otros productores |
| Peón de campo | Carga visitas (estado de cada colmena, fotos, alimentación) sin conexión; sincroniza al volver | Dar de alta o borrar apiarios; ver tambores |
| Técnico sanitario de la cooperativa | Registra tratamientos y alertas sanitarias de cualquier apiario; cierra alertas | Modificar tambores |
| Administración de la cooperativa | Recibe tambores, los pesa y los asocia a un apiario; ve el panel completo | Cargar visitas |
| Inspector del organismo sanitario | Consulta tratamientos y alertas de los últimos 24 meses | Escribir nada; ver kilos producidos ni precios |

- Los kilos y los precios de cada productor son confidenciales: la API no se los entrega a quien no debe verlos;
  la app no los oculta, directamente no le llegan.
- Los peones casi no leen pantallas largas: necesitan instrucciones de una línea, con dibujos y con audio.
- La administración usa la app todo el día y pide atajos de teclado.
- Cada perfil necesita su propia ayuda: lo que hace un peón y lo que hace la administración no se parecen.

## 3. Plataformas y distribución

- Android: productores y peones. Los productores la bajan de la tienda oficial; los peones usan teléfonos de la
  cooperativa sin cuenta de tienda y reciben el instalador directo.
- Los teléfonos de los peones son viejos y no reciben la versión 3 de la app: la versión 2 se sigue corrigiendo
  durante toda la temporada 2027, en paralelo con la 3.
- iOS: técnicos sanitarios, por la tienda oficial.
- Windows: administración, con un instalador interno en las dos computadoras de la planta.
- Habrá un sitio web público, ya decidido y pagado por el programa provincial, donde los productores aprenden a usar
  la app paso a paso, en los dos idiomas.
- El organismo sanitario tiene un asistente conversacional que responde preguntas de los productores; quiere que lea
  ese sitio para contestar sobre la app.

## 4. Componentes

- La app (este repositorio): un solo proyecto MAUI para las tres plataformas.
- La API que guarda los datos vive en otro repositorio, privado, y la mantiene un proveedor externo de la
  cooperativa. La app la consume por versión publicada; el equipo de la app no puede cambiarla.
- El modelo de datos compartido (apiario, colmena, visita, tambor) se publica como paquete .NET público. Vive en su
  propio repositorio, lo escriben a medias el equipo de la app y el proveedor de la API, y sale con su propia
  numeración de versiones, que no sigue a la de la app. La app usa siempre una versión exacta del paquete.
- La app trae adentro una copia de la tabla oficial de productos veterinarios autorizados para colmenas. La publica
  el organismo sanitario y cambia sin aviso, a veces dos veces en un mes.
- La federación de cooperativas tiene otras tres apps en otros repositorios de la misma organización (acopio,
  cosecha, ventas).

## 5. Equipo y aprobación

- Dos programadores: una a tiempo completo y uno los fines de semana.
- Cinco asistentes automáticos de programación que proponen cambios en ramas propias, varios a la vez, en el
  repositorio de la app y en el del paquete.
- El dueño del producto es el presidente de la cooperativa; no es técnico. Firmó un acta, guardada en el
  repositorio, que autoriza a la programadora a fusionar sin él cualquier cambio cuyas verificaciones automáticas
  pasen, y a los asistentes automáticos a fusionar sus propias ramas en las mismas condiciones, salvo lo del punto
  siguiente.
- El técnico sanitario jefe tiene que dar su visto bueno a todo cambio que toque alertas o tratamientos; eso no se
  fusiona sin él.
- El convenio con el programa provincial enumera 46 exigencias numeradas (EX-01 a EX-46). La numeración es común a
  las cuatro apps de la federación: a Colmenar le tocan de EX-31 a EX-46. Cada entrega tiene que decir qué
  exigencias cumple.
- La cooperativa está certificada en una norma de calidad: todo procedimiento escrito lleva un encabezado con
  código, versión, quién lo aprobó y fecha de aprobación, y ninguno puede pasar más de 90 días sin revisarse.
- La escuela agrotécnica dicta un curso anual en el que los alumnos resuelven ejercicios sobre una copia de este
  repositorio; el docente pide que cada ejercicio tenga su enunciado y su solución.

## 6. Público y privado

- Este repositorio es público. El repositorio de la API es privado. El del paquete es público.
- El nombre del proveedor de la API y el del organismo sanitario no se publican en ningún lado.
- Las ubicaciones de los apiarios son secretas (el robo de colmenas es el problema principal): no pueden aparecer en
  capturas, ejemplos ni datos de prueba publicados.
- Los nombres de los alumnos de la escuela no se publican.

## 7. Idiomas

- La app sale en español y en portugués: parte de los productores son de la zona de frontera y no leen español.
- Los textos de la app para los peones se graban además como audio en los dos idiomas.
- El equipo escribe y habla en español. El proveedor de la API, que escribe la mitad del paquete, sólo lee
  portugués: todo lo que se escribe en el repositorio del paquete va en los dos idiomas.
- La escuela agrotécnica está del lado brasileño de la frontera: el curso se dicta en portugués.

## 8. Máquinas de compilación

- Hay una sola máquina Linux de la cooperativa que compila Android y el paquete .NET.
- Para iOS se usa una Mac prestada, disponible sólo los jueves.
- La administración compró una máquina Windows que compila el instalador de Windows; ya no se arma a mano.
- La organización donde se aloja el código sólo permite ejecutar automatismos definidos dentro de ella misma; no
  deja usar los de otras organizaciones.
- La cooperativa paga el plan del alojamiento del código que impide fusionar una rama con las verificaciones
  fallidas, y la certificación de calidad exige que nada salga publicado con una verificación fallida.
- Durante la temporada de cosecha (octubre a marzo) hay que comprobar todos los días que la copia de la tabla de
  productos autorizados coincide con la publicada por el organismo; fuera de temporada, una vez al mes.

## 9. Lo no decidido

- Si el inspector del organismo sanitario tendrá acceso a la app o recibirá un reporte mensual: no decidido.
- Si los peones van a pasar a la tienda oficial cuando la cooperativa compre cuentas: no decidido.
- Si la escuela agrotécnica seguirá con el curso después de 2027: no decidido.
