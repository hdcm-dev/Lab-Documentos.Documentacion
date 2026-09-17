# Corpus de logs del escenario testigo — cómo se ven y qué leer

**Tipo:** segundo fixture. Derivado del `Escenario-Testigo.md`. Contiene los eventos **renderizados tal como Windows los muestra** (texto real del Visor de eventos), cada uno con "qué leer en él".
**Regla:** todo valor aquí es consistente con la línea de tiempo del escenario. Los renders reproducen el formato real de Windows; los valores son del caso sintético.

> **Doble vista.** Cada evento existe en dos lugares: el **log local** de SRV-FILE01 (que el atacante borró a las 03:40, así que allí faltan los previos) y la **copia del colector** SRV-LOG01 (que los recibió en el momento). Se indica en cuál se encuentra.

---

## 1. 4625 — Inicio de sesión fallido (la ráfaga previa) · [colector]

Aparecen ~40 seguidos entre 03:02 y 03:13. Uno de ellos:

```
Registro: Security   Id de evento: 4625   Nivel: Información
Fecha y hora: 15/09/2026 03:11:57
Origen: Microsoft-Windows-Security-Auditing
Equipo: SRV-FILE01.contoso.local

Error al iniciar sesión una cuenta.

Sujeto:
    Id. de seguridad:        NULL SID
    Nombre de cuenta:        -
Tipo de inicio de sesión:    10
Cuenta para la que error el inicio de sesión:
    Id. de seguridad:        NULL SID
    Nombre de cuenta:        soporte
    Dominio de la cuenta:    CONTOSO
Información de error:
    Motivo del error:        Nombre de usuario desconocido o contraseña incorrecta.
    Estado:                  0xC000006D
    Subestado:               0xC000006A
Información de red:
    Nombre de estación:      -
    Dirección de red de origen: 203.0.113.14
    Puerto de origen:        49722
```

**Qué leer:**
- **Nombre de cuenta** (`soporte`): contra quién prueban.
- **Tipo de inicio de sesión** `10`: es por escritorio remoto (RDP).
- **Subestado** `0xC000006A`: "contraseña incorrecta" (el usuario existe, fallan la clave). Si fuera `0xC0000064` sería "usuario no existe". Esta distinción dice si están **adivinando la contraseña de una cuenta real**.
- **Dirección de red de origen** `203.0.113.14`: una IP externa.
- **La repetición**: 40 de estos en 11 minutos contra la misma cuenta desde la misma IP = fuerza bruta. Un fallo suelto es ruido; la **ráfaga** es el patrón.

---

## 2. 4624 — El inicio de sesión que tuvo éxito · [colector]

```
Registro: Security   Id de evento: 4624
Fecha y hora: 15/09/2026 03:14:22
Equipo: SRV-FILE01.contoso.local

Se inició sesión correctamente.

Nuevo inicio de sesión:
    Id. de seguridad:        CONTOSO\soporte
    Nombre de cuenta:        soporte
    Dominio de la cuenta:    CONTOSO
    Id. de inicio de sesión: 0x3E9A11
Tipo de inicio de sesión:    10
Información de red:
    Nombre de estación:      KALI
    Dirección de red de origen: 203.0.113.14
    Puerto de origen:        50134
Proceso de inicio de sesión: User32
Paquete de autenticación:    Negotiate
```

**Qué leer:**
- **Tipo de inicio de sesión** `10` (RDP) + **Dirección de origen** externa `203.0.113.14` = acceso remoto desde afuera. El más alarmante de los tipos si la IP es desconocida.
- **Id. de inicio de sesión** `0x3E9A11`: el "número de sesión". Guárdelo: permite seguir **todo lo que hizo esta sesión** (los eventos siguientes lo repiten).
- **Nombre de estación** `KALI`: el nombre del equipo del atacante, que a veces se filtra. Un nombre que no es de la empresa es un indicio.
- **La hora**: 03:14, justo al final de la ráfaga de 4625. La secuencia (muchos fallos → un éxito) es la firma de una contraseña finalmente adivinada.

---

## 3. 4720 — Se creó una cuenta de usuario · [colector]

```
Registro: Security   Id de evento: 4720
Fecha y hora: 15/09/2026 03:16:05
Equipo: SRV-FILE01.contoso.local

Se creó una cuenta de usuario.

Sujeto:
    Id. de seguridad:        CONTOSO\soporte
    Nombre de cuenta:        soporte
    Id. de inicio de sesión: 0x3E9A11
Nueva cuenta:
    Id. de seguridad:        SRV-FILE01\svc_update
    Nombre de cuenta:        svc_update
    Dominio de la cuenta:    SRV-FILE01
```

**Qué leer:**
- **Sujeto** (`soporte`, Id `0x3E9A11`): **quién** la creó — la misma sesión del 4624. El Id de inicio de sesión los enlaza.
- **Nueva cuenta** (`svc_update`, dominio `SRV-FILE01`): es **local** del servidor, no del dominio. Un nombre que imita "servicio de actualización".
- **La pregunta**: ¿alguien del equipo de sistemas creó `svc_update` a las 03:16? Si nadie lo reconoce, es una puerta trasera.

---

## 4. 4732 — Se agregó a un grupo con privilegios · [colector]

```
Registro: Security   Id de evento: 4732
Fecha y hora: 15/09/2026 03:16:40
Equipo: SRV-FILE01.contoso.local

Se agregó un miembro a un grupo local con seguridad habilitada.

Sujeto:
    Nombre de cuenta:        soporte
    Id. de inicio de sesión: 0x3E9A11
Miembro:
    Id. de seguridad:        SRV-FILE01\svc_update
Grupo:
    Nombre del grupo:        Administradores
    Dominio del grupo:       Builtin
```

**Qué leer:**
- **Grupo** `Administradores` (Builtin): el grupo de administración local. Sumar a alguien aquí es **darle control total** del equipo.
- **Miembro** `svc_update`: la cuenta recién creada.
- **Sujeto** `soporte` (mismo Id de sesión): la cadena está completa — la misma sesión entró (4624), creó la cuenta (4720) y la hizo administradora (4732) en 35 segundos. Ningún humano administra así de rápido: es un script.

---

## 5. 7045 — Se instaló un servicio nuevo · [colector, registro System]

```
Registro: System   Id de evento: 7045
Fecha y hora: 15/09/2026 03:22:11
Origen: Service Control Manager
Equipo: SRV-FILE01.contoso.local

Se instaló un servicio en el sistema.

    Nombre del servicio:     WinDefendUpd
    Nombre de archivo:       C:\Users\Public\update.exe
    Tipo de servicio:        modo usuario
    Tipo de inicio:          inicio automático
    Cuenta del servicio:     LocalSystem
```

**Qué leer:**
- **Nombre de archivo** `C:\Users\Public\update.exe`: un servicio legítimo **jamás** vive en `C:\Users\Public`. Este solo dato ya basta para investigar.
- **Nombre del servicio** `WinDefendUpd`: imita a Windows Defender para pasar desapercibido en una lista.
- **Tipo de inicio** `automático`: arranca solo en cada reinicio = persistencia.
- **Cuenta** `LocalSystem`: corre con los máximos privilegios del equipo.
- **Este evento está en el registro System, no Security.** Importa: al borrar solo el Security, el atacante puede haber dejado este intacto. Mire siempre ambos.

---

## 6. 4698 — Se creó una tarea programada · [colector]

```
Registro: Security   Id de evento: 4698
Fecha y hora: 15/09/2026 03:23:02
Equipo: SRV-FILE01.contoso.local

Se creó una tarea programada.

Sujeto:
    Nombre de cuenta:        svc_update
Nombre de la tarea:          \SystemUpdate
Contenido de la tarea (XML):
    <Triggers><LogonTrigger><Enabled>true</Enabled></LogonTrigger></Triggers>
    <Actions>
      <Exec>
        <Command>powershell.exe</Command>
        <Arguments>-w hidden -enc SQBFAFgAIAAoAE4AZQB3AC0ATwBiAG...</Arguments>
      </Exec>
    </Actions>
```

**Qué leer:**
- **Sujeto** `svc_update`: ahora actúa la cuenta que el atacante creó (ya no `soporte`). El atacante "ascendió" a su propia puerta trasera.
- **Disparador** `LogonTrigger`: se ejecuta **cada vez que alguien inicia sesión** = persistencia redundante (además del servicio).
- **Argumentos** `-w hidden -enc ...`: `-w hidden` = ventana oculta; `-enc` = comando en Base64 para que usted no lo lea. Dos banderas de ocultamiento en la misma línea. (Decodificar ese Base64 revela lo que hace; es materia del §6.7.)

---

## 7. 1102 — El registro de seguridad fue borrado · [log LOCAL]

Este es el corazón del caso. Es el **primer** evento del log local tras el borrado.

```
Registro: Security   Id de evento: 1102
Fecha y hora: 15/09/2026 03:40:11
Origen: Microsoft-Windows-Eventlog
Equipo: SRV-FILE01.contoso.local

El registro de auditoría se borró.

Sujeto:
    Id. de seguridad:        SRV-FILE01\svc_update
    Nombre de cuenta:        svc_update
    Dominio:                 SRV-FILE01
    Id. de inicio de sesión: 0x5F2C08
```

**Qué leer:**
- **Sujeto** `svc_update`: **quién** borró el log. No fue un administrador conocido: fue la cuenta que el propio atacante creó.
- **La hora** `03:40`: madrugada, fuera de cualquier ventana de mantenimiento.
- **Que sea el primer evento del log**: todo lo anterior (los 4624/4720/4732/4698 de arriba) **ya no está aquí**. Por eso se leen desde el colector.
- **1102 es una acción explícita**: Windows solo lo genera cuando alguien **ejecuta la orden de vaciar** el registro. No se produce por llenarse el disco ni por rotación. Ver la sección de intencionalidad (guía §5.5.3).

---

## 8. Contraste: cómo se ve un log que NO fue tocado

Para calibrar el ojo, un tramo del registro System **sano** (rotación normal, sin 1102/104):

```
RecordId  TimeCreated           Id    Origen
--------  -----------           --    ------
 184402   15/09/2026 02:58:03   7036  Service Control Manager  (servicio en ejecución)
 184403   15/09/2026 03:00:11   6013  EventLog                 (tiempo de actividad del sistema)
 184404   15/09/2026 03:22:11   7045  Service Control Manager  (WinDefendUpd instalado)
 184405   15/09/2026 03:45:02   7040  Service Control Manager  (cambio de tipo de inicio)
```

**Qué leer:**
- **RecordId correlativo y alto** (184402, 184403…): el log **no** fue vaciado (si lo hubieran vaciado, arrancaría cerca de 1).
- **Continuidad temporal**: no hay huecos grandes ni saltos de numeración.
- Comparar esto con el Security local (que arranca en el 1102 con RecordId bajo) hace evidente, por diferencia, que **el Security fue borrado y el System no**.
