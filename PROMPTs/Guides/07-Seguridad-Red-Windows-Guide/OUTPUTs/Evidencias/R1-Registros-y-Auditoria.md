---
title: "R1 — Registro de eventos y política de auditoría (base de evidencia verificable)"
fecha_de_consulta: 2026-09-18
alcance: >
  Hechos verificados con fuente oficial (Microsoft Learn, Sysinternals, MITRE ATT&CK)
  sobre el registro de eventos de Windows, herramientas de consulta, tamaños y
  retención del registro Security, IDs de evento relevantes, tipos de inicio de
  sesión, política de auditoría por defecto y recomendada, borrado de registros,
  Windows Event Forwarding y Sysmon. Escenario de referencia: Windows Server 2019
  miembro de un dominio de Active Directory con sospecha de intrusión y de borrado
  de registros. No es una guía: es materia prima con cita.
regla: "Todo hecho lleva ID de fuente. Lo que no se pudo confirmar en fuente oficial se marca «No verificado»."
---

# R1 — Registro de eventos y política de auditoría

## Tabla de fuentes

| ID | Título | URL |
| --- | --- | --- |
| F1-01 | Appendix L - Events to Monitor (Windows Server / AD DS) | https://learn.microsoft.com/en-us/windows-server/identity/ad-ds/plan/appendix-l--events-to-monitor |
| F1-02 | 4624(S) An account was successfully logged on. | https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-10/security/threat-protection/auditing/event-4624 |
| F1-03 | 4625(F) An account failed to log on. | https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-10/security/threat-protection/auditing/event-4625 |
| F1-04 | 4688(S) A new process has been created. | https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-10/security/threat-protection/auditing/event-4688 |
| F1-05 | 1102(S) The audit log was cleared. | https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-10/security/threat-protection/auditing/event-1102 |
| F1-06 | 1100(S) The event logging service has shut down. | https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-10/security/threat-protection/auditing/event-1100 |
| F1-07 | 1104(S) The security log is now full. | https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-10/security/threat-protection/auditing/event-1104 |
| F1-08 | Get-WinEvent (Microsoft.PowerShell.Diagnostics) | https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.diagnostics/get-winevent |
| F1-09 | wevtutil (Windows Commands) | https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/wevtutil |
| F1-10 | auditpol get (Windows Commands) | https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/auditpol-get |
| F1-11 | Advanced security audit policy settings | https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-10/security/threat-protection/auditing/advanced-security-audit-policy-settings |
| F1-12 | System Audit Policy recommendations | https://learn.microsoft.com/en-us/windows-server/identity/ad-ds/plan/security-best-practices/audit-policy-recommendations |
| F1-13 | Advanced security auditing FAQ | https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-10/security/threat-protection/auditing/advanced-security-auditing-faq |
| F1-14 | EventLogService Policy CSP | https://learn.microsoft.com/en-us/windows/client-management/mdm/policy-csp-eventlogservice |
| F1-15 | Use Windows Event Forwarding to help with intrusion detection | https://learn.microsoft.com/en-us/windows/security/operating-system-security/device-management/use-windows-event-forwarding-to-assist-in-intrusion-detection |
| F1-16 | Setting up a Source Initiated Subscription (Windows Event Collector) | https://learn.microsoft.com/en-us/windows/win32/wec/setting-up-a-source-initiated-subscription |
| F1-17 | about_Logging (Windows PowerShell 5.1) | https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_logging?view=powershell-5.1 |
| F1-18 | about_Logging_Windows (PowerShell 7.x) | https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_logging_windows |
| F1-19 | Sysmon (Sysinternals) | https://learn.microsoft.com/en-us/sysinternals/downloads/sysmon |
| F1-20 | MITRE ATT&CK T1070.001 Clear Windows Event Logs (v14) | https://attack.mitre.org/versions/v14/techniques/T1070/001/ |
| F1-21 | MITRE ATT&CK T1562.002 Disable Windows Event Logging (v14) | https://attack.mitre.org/versions/v14/techniques/T1562/002/ |
| F1-22 | 5145(S, F) A network share object was checked… | https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-10/security/threat-protection/auditing/event-5145 |
| F1-23 | 4697(S) A service was installed in the system. | https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-10/security/threat-protection/auditing/event-4697 |
| F1-24 | Troubleshoot unexpected reboots using system event logs | https://learn.microsoft.com/en-us/troubleshoot/windows-server/performance/troubleshoot-unexpected-reboots-system-event-logs |
| F1-25 | Microsoft Defender Antivirus event IDs and error codes | https://learn.microsoft.com/en-us/defender-endpoint/troubleshoot-microsoft-defender-antivirus |
| F1-26 | Windows Event Log (Win32 API, visión general) | https://learn.microsoft.com/en-us/windows/win32/wes/windows-event-log |
| F1-27 | Troubleshoot Azure VM RDP connection issues by Event ID | https://learn.microsoft.com/en-us/troubleshoot/azure/virtual-machines/windows/event-id-troubleshoot-vm-rdp-connecton |

> Nota de método: las páginas «event-NNNN» y «advanced-security-*» viven hoy bajo
> `previous-versions/…/windows-10/security/threat-protection/auditing/` (archivo de
> Microsoft Learn). Son la documentación oficial de esos IDs; el contenido es el
> mismo que se publicaba en `/windows/security/threat-protection/auditing/`.

---

## 1. Qué es el registro de eventos y qué canales importan

| # | Hecho | Fuente |
| --- | --- | --- |
| 1.1 | Windows Event Log es la API/infraestructura que sustituye a la antigua Event Logging a partir de Windows Vista / Windows Server 2008: «Windows Event Log supersedes the Event Logging API beginning with the Windows Vista operating system.» Incluye las funciones que un consumidor de eventos, como el Visor de eventos, usa para leer y representar los eventos. | F1-26 |
| 1.2 | `Get-WinEvent` «gets events from event logs, including classic logs, such as the **System** and **Application** logs» y también de canales nuevos y de archivos ETW. Los registros clásicos aparecen con `IsClassicLog : True` (ejemplo documentado: Security). | F1-08 |
| 1.3 | Ubicación física de los .evtx: la propiedad `LogFilePath` de un registro es `%SystemRoot%\System32\Winevt\Logs\<Nombre>.evtx` (ejemplos documentados: `…\Setup.evtx` y `…\Security.evtx`). | F1-08 |
| 1.4 | MITRE describe la misma ruta al recomendar restringir permisos: los .evtx están en `C:\Windows\system32\Winevt\Logs`. | F1-21 |
| 1.5 | El registro Security lo escribe el proveedor `Microsoft-Windows-Security-Auditing` (GUID `{54849625-5478-4994-A5BA-3E3B0328C30D}`); los eventos 1100/1102/1104 los escribe `Microsoft-Windows-Eventlog` en el canal Security. | F1-02, F1-05, F1-06, F1-07 |
| 1.6 | Los canales de aplicaciones y servicios viven en el Visor de eventos bajo **Applications and Services Logs > Microsoft > Windows > …**; ejemplo documentado paso a paso para Windows Defender: abrir `eventvwr.msc` y navegar a *Applications and Services Logs > Microsoft > Windows > Windows Defender > Operational*. | F1-25 |
| 1.7 | Canal de Sysmon: «On Vista and higher, events are stored in `Applications and Services Logs/Microsoft/Windows/Sysmon/Operational`». | F1-19 |
| 1.8 | Canal PowerShell moderno: el registro se llama **Microsoft-Windows-PowerShell** (proveedor ETW `{A0C1853B-5C40-4B15-8766-3CF1C58F985A}`) y el script block logging escribe en **Microsoft-Windows-PowerShell/Operational**. | F1-17 |
| 1.9 | Canal PowerShell clásico: existe el registro **Windows PowerShell** (usado como `-LogName 'Windows PowerShell'`); el evento 800 es «Legacy PowerShell pipeline execution details». | F1-08, F1-15 |
| 1.10 | Canal del Programador de tareas: **Microsoft-Windows-TaskScheduler/Operational**, con 106 (Task Registered), 141 (Task Registration Deleted) y 142 (Task Deleted). | F1-15 |
| 1.11 | Canal de Defender: **Microsoft-Windows-Windows Defender/Operational** (así se lo nombra en las consultas WEF y en el campo *Channel* de la referencia de Defender). | F1-15, F1-25 |
| 1.12 | Canales de Terminal Services citados por Microsoft en consultas de caza: **Microsoft-Windows-TerminalServices-RDPClient/Operational** (1024, intento de conexión saliente). Los canales `TerminalServices-LocalSessionManager/Operational` y `TerminalServices-RemoteConnectionManager/Operational` existen como orígenes de eventos del sistema pero su tabla de IDs no está documentada como referencia. | F1-15, F1-27 |
| 1.13 | Canal de diagnóstico de reenvío: **Eventlog-ForwardingPlugin/Operational** registra éxito, aviso y error de las suscripciones WEF en el equipo origen. | F1-15, F1-16 |

---

## 2. Herramientas y sintaxis exacta

### 2.1 Visor de eventos

| # | Hecho | Fuente |
| --- | --- | --- |
| 2.1.1 | Se abre con Windows+R → `eventvwr.msc` → Aceptar (procedimiento textual de Microsoft). | F1-25 |
| 2.1.2 | El Visor de eventos permite generar consultas XML válidas: «use the **Create Custom View** and **Filter Current Log** features in Windows Event Viewer… then click the XML tab», y ese XML se puede pegar en `-FilterXml`. | F1-08 |

### 2.2 `Get-WinEvent`

| # | Hecho | Fuente |
| --- | --- | --- |
| 2.2.1 | Conjuntos de parámetros documentados: `Get-WinEvent [[-LogName] <String[]>] [-MaxEvents <Int64>] [-ComputerName] [-Credential] [-FilterXPath] [-Force] [-Oldest]`; `-ListLog <String[]>`; `-ListProvider <String[]>`; `-ProviderName <String[]>`; `-Path <String[]>`; `-FilterHashtable <Hashtable[]>`; `-FilterXml <XmlDocument>`. | F1-08 |
| 2.2.2 | Claves válidas de `-FilterHashtable`: **LogName**, **ProviderName**, **Path**, **Keywords**, **ID**, **Level**, **StartTime**, **EndTime**, **UserID**, **Data**, `<named-data>`, **SuppressHashFilter**. | F1-08 |
| 2.2.3 | Reglas del hashtable: claves y valores no distinguen mayúsculas; los comodines sólo valen en `LogName` y `ProviderName`; cada clave aparece una sola vez; `Path` admite `.etl`, `.evt` y `.evtx`; `UserID` admite un SID o una cuenta de dominio. | F1-08 |
| 2.2.4 | Ejemplo oficial: `Get-WinEvent -FilterHashtable @{ LogName='Application'; StartTime=$Date; Id='1003' }`. | F1-08 |
| 2.2.5 | `-MaxEvents`: «Specifies the maximum number of events that are returned»; por defecto devuelve todos. `-Oldest` invierte el orden (obligatorio para `.etl`, `.evt` y registros de depuración/análisis). | F1-08 |
| 2.2.6 | `-ListLog` devuelve objetos **EventLogConfiguration** con `LogMode`, `MaximumSizeInBytes`, `RecordCount`, `LogName`, `LogFilePath`, `IsLogFull`, `IsClassicLog`, etc. Ejemplo: `Get-WinEvent -ListLog Security | Format-List -Property *`. | F1-08 |
| 2.2.7 | Límite práctico: «the `Get-WinEvent` cmdlet queries the Windows API which has a limit of 256» registros por consulta. | F1-08 |
| 2.2.8 | Filtrar con `-FilterHashtable`/`-FilterXPath` es más eficiente que `Where-Object`: «Filters are applied as the objects are retrieved. `Where-Object` retrieves all of the objects, then applies filters». | F1-08 |
| 2.2.9 | Sin privilegios de administrador pueden aparecer errores al leer ciertos registros (p. ej. Security). | F1-08 |

### 2.3 `wevtutil`

| # | Hecho (sintaxis literal) | Fuente |
| --- | --- | --- |
| 2.3.1 | `{el \| enum-logs}` — «Displays the names of all logs.» Ejemplo: `wevtutil el`. | F1-09 |
| 2.3.2 | `{gl \| get-log} <Logname> [/f:<Format>]` — «Displays configuration information for the specified log, which includes whether the log is enabled or not, the current maximum size limit of the log, and the path to the file where the log is stored.» Ejemplo: `wevtutil gl System /f:xml`. | F1-09 |
| 2.3.3 | `{gli \| get-loginfo} <Logname>` — estado del registro. Ejemplo: `wevtutil gli Application`. | F1-09 |
| 2.3.4 | `{qe \| query-events} <Path> [/lf:] [/sq:] [/q:] [/rd:] [/f:] [/c:] …` — lee eventos de un registro, un archivo o una consulta estructurada. Ejemplo: `wevtutil qe Application /c:3 /rd:true /f:text`. | F1-09 |
| 2.3.5 | `{epl \| export-log} <Path> <Exportfile> [/ow:]` — exporta eventos a un archivo. Ejemplo: `wevtutil epl System C:\backup\system0506.evtx`. | F1-09 |
| 2.3.6 | `{cl \| clear-log} <Logname> [/bu:<Backup>]` — «Clears events from the specified event log. The **/bu** option can be used to back up the cleared events.» Ejemplo: `wevtutil cl Application /bu:C:\admin\backups\a10306.evtx`. | F1-09 |
| 2.3.7 | `{sl \| set-log} <Logname> [/e:] [/ms:] [/rt:] [/ab:] [/ca:] …` modifica la configuración; `/ms:<MaxSize>` fija el tamaño en bytes («The minimum log size is 1048576 bytes (1024KB) and log files are always multiples of 64KB»). | F1-09 |
| 2.3.8 | `/rt:<Retention>`: «If an event log reaches its maximum size and the log retention mode is true, existing events are retained, and incoming events are discarded. If the log retention mode is false, incoming events overwrite the oldest events in the log.» | F1-09 |
| 2.3.9 | `/ab:<Auto>`: «If this value is true, the log will be backed up automatically when it reaches the maximum size. If this value is true, the retention (specified with the **/rt** option) must also be set to true.» | F1-09 |
| 2.3.10 | `{al \| archive-log} <Logpath>` archiva un .evtx en formato autocontenido (crea subcarpeta de locale). Ejemplo: `wevtutil archive-log "C:\backup\Application.evtx" /locale:en-us`. | F1-09 |
| 2.3.11 | Uso forense útil: `wevtutil gp Microsoft-Windows-Security-Auditing /ge /gm:true` «to get a detailed listing of all security event IDs». | F1-01 |
| 2.3.12 | `wevtutil qe` con XPath, ejemplo oficial en una sola línea: `wevtutil qe system /c:1 /f:text /q:"Event[System[Provider[@Name='Schannel'] and EventID=36871 and TimeCreated[timediff(@SystemTime) <= 86400000]]]"`. | F1-27 |

### 2.4 `auditpol`

| # | Hecho | Fuente |
| --- | --- | --- |
| 2.4.1 | Sintaxis: `auditpol /get [/user[:<username>|<{sid}>]] [/category:*|<name>|<{guid}>] [/subcategory:*|<name>|<{guid}>] [/option:<option name>] [/sd] [/r]`. | F1-10 |
| 2.4.2 | `/category`: «One or more audit categories specified by globally unique identifier (GUID) or name. An asterisk (*) may be used to indicate that all audit categories should be queried.» → de ahí `auditpol /get /category:*`. | F1-10 |
| 2.4.3 | `/r` muestra la salida en formato informe CSV; `/option` recupera CrashOnAuditFail, FullprivilegeAuditing, AuditBaseObjects, AuditBasedirectories; `/sd` el descriptor de seguridad de la política. | F1-10 |
| 2.4.4 | Permisos: hace falta permiso de lectura sobre el objeto de política, o el derecho **Manage auditing and security log** (SeSecurityPrivilege). | F1-10 |
| 2.4.5 | Para listar categorías: `auditpol /list /category`. | F1-10 |
| 2.4.6 | En un equipo individual, «the `Auditpol` command-line tool can be used to complete many important audit policy-related management tasks». | F1-13 |

---

## 3. Tamaño máximo y comportamiento al llenarse (registro Security)

| # | Hecho | Fuente |
| --- | --- | --- |
| 3.1 | Tamaño por defecto del registro **Security**: la directiva «Specify the maximum log file size (KB)» para Security admite «between 20 megabytes (20480 kilobytes) and 2 terabytes (2147483647 kilobytes)» y, si no se configura, «the maximum size of the log file will be set to the locally configured value… and it **defaults to 20 megabytes**». | F1-14 |
| 3.2 | Para **Application** y **System** la misma directiva admite desde 1 MB y «it defaults to 1 megabyte» cuando no se configura. (Ver §10, contradicción con el saber común y con la salida de ejemplo de `Get-WinEvent`.) | F1-14 |
| 3.3 | Comportamiento al llenarse (directiva `Channel_Log_Retention_1`, «Control Event Log behavior when the log file reaches its maximum size»): «If you enable this policy setting and a log file reaches its maximum size, new events aren't written to the log and are lost. If you disable or don't configure this policy setting and a log file reaches its maximum size, **new events overwrite old events**.» | F1-14 |
| 3.4 | El archivado depende de otra opción: «Old events may or may not be retained according to the "Backup log automatically when full" policy setting». | F1-14 |
| 3.5 | Equivalente por línea de comandos: `/rt:true` = conservar y descartar los nuevos; `/rt:false` = sobrescribir los más antiguos; `/ab:true` = copia automática al llenarse (exige `/rt:true`). | F1-09 |
| 3.6 | Cómo verlo: `wevtutil gl Security` (muestra si está habilitado, el límite de tamaño y la ruta del archivo) y `Get-WinEvent -ListLog Security | Format-List -Property *` (propiedades `MaximumSizeInBytes`, `LogMode`, `IsLogFull`, `LogFilePath`, `RecordCount`). | F1-09, F1-08 |
| 3.7 | Cómo cambiarlo por PowerShell (ejemplo oficial): `$log = Get-WinEvent -ListLog Security; $log.MaximumSizeInBytes = 1gb; $log.SaveChanges()` (requiere privilegios; el ejemplo captura `System.UnauthorizedAccessException`). | F1-08 |
| 3.8 | Si el modo es «Do not overwrite events (Clear logs manually)» y el registro se llena, se genera el evento **1104** y hay que archivar o limpiar de inmediato. | F1-07 |
| 3.9 | En WEF, el registro local es el búfer: «The WEF client machines local event log is the buffer… To increase the "buffer size", increase the maximum file size of the specific event log file». Cuando el registro sobrescribe, **no** hay aviso al colector de que se perdieron eventos. | F1-15 |

---

## 4. IDs de evento

### 4.1 Registro Security — significado oficial

Salvo indicación, el texto es el de la columna «Event Summary» de F1-01.

| ID | Significado (literal, inglés) | Detalle adicional / subcategoría | Fuente |
| --- | --- | --- | --- |
| 4624 | An account was successfully logged on. | «This event generates when a logon session is created (on destination machine). It generates on the computer that was accessed». Subcategoría *Audit Logon*. | F1-01, F1-02 |
| 4625 | An account failed to log on. | «This event is logged for any logon failure.» Subcategorías *Audit Account Lockout* y *Audit Logon*. | F1-01, F1-03 |
| 4634 | An account was logged off. | — | F1-01 |
| 4647 | User initiated logoff. | Usado en la suscripción WEF base como «user initiated logoff». | F1-01, F1-15 |
| 4648 | A logon was attempted using explicit credentials. | Correlacionable con 4624 por **Logon GUID**. | F1-01, F1-02 |
| 4672 | Special privileges assigned to new logon. | WEF: «Special Privileges (Admin-equivalent Access) assigned to new logon», con supresión de S-1-5-18. | F1-01, F1-15 |
| 4688 | A new process has been created. | «This event generates every time a new process starts.» Subcategoría *Audit Process Creation*. | F1-01, F1-04 |
| 4697 | Attempt to install a service. (título de la página: «A service was installed in the system») | Subcategoría *Audit Security System Extension*; versión mínima Windows Server 2016/Windows 10. Campos: Service Name, Service File Name, Service Type, Service Start Type, Service Account. | F1-01, F1-23 |
| 4698 | A scheduled task was created. | — | F1-01 |
| 4699 | A scheduled task was deleted. | — | F1-01 |
| 4702 | A scheduled task was updated. | — | F1-01 |
| 4719 | System audit policy was changed. | Criticidad **High** en la tabla de Microsoft; «critical events, like audit policy changes (Event ID 4719), are typically logged» por defecto. | F1-01 |
| 4720 | A user account was created. | — | F1-01 |
| 4722 | A user account was enabled. | — | F1-01 |
| 4724 | An attempt was made to reset an account's password. | Criticidad **Medium**. | F1-01 |
| 4726 | A user account was deleted. | — | F1-01 |
| 4728 | A member was added to a security-enabled global group. | — | F1-01 |
| 4732 | A member was added to a security-enabled local group. | WEF lo usa para «New user added to local security group». | F1-01, F1-15 |
| 4756 | A member was added to a security-enabled universal group. | — | F1-01 |
| 4738 | A user account was changed. | — | F1-01 |
| 4740 | A user account was locked out. | — | F1-01 |
| 4768 | A Kerberos authentication ticket (TGT) was requested. | Legacy 672/676. | F1-01 |
| 4769 | A Kerberos service ticket was requested. | Legacy 673; correlacionable por **Logon GUID** con 4624. | F1-01, F1-02 |
| 4771 | Kerberos pre-authentication failed. | Legacy 675. | F1-01 |
| 4776 | The domain controller attempted to validate the credentials for an account. | (4777 = «failed to validate»). WEF lo llama «Local credential authentication events». | F1-01, F1-15 |
| 4778 | A session was reconnected to a Window Station. | WEF: «TS Session reconnect (4778)». | F1-01, F1-15 |
| 4779 | A session was disconnected from a Window Station. | WEF: «TS Session disconnect (4779)». | F1-01, F1-15 |
| 5140 | A network share object was accessed. | En WEF se filtran IPC$ y NetLogon por ruido. | F1-01, F1-15 |
| 5145 | (no figura en F1-01) «A network share object was checked to see whether client can be granted desired access.» | «This event generates every time network share object (file or folder) was accessed.» Subcategoría *Audit Detailed File Share*. Los eventos de fallo sólo se generan si el acceso se deniega a nivel de recurso compartido, no NTFS. | F1-22 |
| 5156 | The Windows Filtering Platform has allowed a connection. | (5157 = conexión bloqueada.) | F1-01 |
| 1100 | (Security) The event logging service has shut down. | «This event generates every time Windows Event Log service has shut down. It also generates during normal system shutdown. This event doesn't generate during emergency system reset.» | F1-06 |
| 1102 | The audit log was cleared. | «This event generates every time Windows Security audit log was cleared.» Criticidad **Medium to High**. Registra el SID/cuenta que lo borró. | F1-01, F1-05 |
| 1104 | (Security) The security log is now full. | «This event generates every time Windows security log becomes full», p. ej. con retención «Do not overwrite events (Clear logs manually)». | F1-07 |

Otros IDs citados por Microsoft como alta criticidad y útiles en este escenario: 4618 (patrón de evento monitorizado), 4649 (replay attack), 4765/4766 (SID History), 4964 (special groups assigned to a new logon), 4616 (system time changed), 4657 (registry value modified), 5142/5144 (creación/borrado de recurso compartido), 4689 (process exited) — F1-01, F1-15.

### 4.2 Códigos de estado/substatus más comunes de 4625

Literal de la tabla «Monitor for all events with the fields and values in the following table» (F1-03). Para 4625 el campo **Status** típico es `0xC0000234` y el **Failure Reason** «Account locked out» (F1-03).

| Código | Significado (literal) | Fuente |
| --- | --- | --- |
| 0xC0000064 | «User logon with misspelled or bad user account». Varios seguidos pueden indicar enumeración de usuarios. | F1-03 |
| 0xC000006A | «User logon with misspelled or bad password» — vigilar rachas en cuentas críticas o de servicio. | F1-03 |
| 0xC000006D | «This is either due to a bad username or authentication information». | F1-03 |
| 0xC0000234 | Cuenta bloqueada (valor típico del campo Status con Failure Reason «Account locked out»). | F1-03 |
| 0xC000006F | «User logon outside authorized hours». | F1-03 |
| 0xC0000070 | «User logon from unauthorized workstation». | F1-03 |
| 0xC0000072 | «User logon to account disabled by administrator». | F1-03 |
| 0xC0000193 | «User logon with expired account». | F1-03 |
| 0xC000015B | «The user has not been granted the requested logon type (aka logon right) at this machine». | F1-03 |
| 0xC000005E | «There are currently no logon servers available to service the logon request». | F1-03 |
| 0xC0000192 | «An attempt was made to logon, but the Netlogon service was not started». | F1-03 |
| 0xC0000413 | «Logon Failure: The machine you are logging onto is protected by an authentication firewall…». | F1-03 |

Referencia general de códigos: Microsoft remite a **NTSTATUS Values** (`/openspecs/windows_protocols/ms-erref/…`) para el resto de Status/SubStatus (F1-03).

### 4.3 Línea de comandos en 4688

| # | Hecho | Fuente |
| --- | --- | --- |
| 4.3.1 | «**Process Command Line** … contains the name of executable and arguments which were passed to it. You must enable "Administrative Templates\System\Audit Process Creation\Include command line in process creation events" group policy to include command line in process creation events». | F1-04 |
| 4.3.2 | «By default **Process Command Line** field is empty.» | F1-04 |
| 4.3.3 | El campo existe desde la versión 1 del evento (Windows Server 2012 R2 / Windows 8.1): «Added "Process Command Line" field». | F1-04 |
| 4.3.4 | La subcategoría que hay que habilitar es *Audit Process Creation* (Detailed Tracking). | F1-04, F1-11 |

### 4.4 Registro System

| ID | Origen (Source) | Significado | Fuente |
| --- | --- | --- | --- |
| 104 | Microsoft-Windows-Eventlog | Borrado de un registro distinto de Security: la consulta base de WEF lo etiqueta «Other Log cleared events (104)» y selecciona `Path="System"`. MITRE lo lista como indicador junto a 1100/1102/1104. | F1-15, F1-20 |
| 7045 | Service Control Manager | «A service was installed in the system. Service Name: … Service File Name: … Service Type: … Service Start Type: … Service Account: …» (texto literal del evento en la documentación). | F1-24 |
| 6005 | EventLog | «The Event log service was started.» | F1-24 |
| 6008 | EventLog | «The previous system shutdown at <Time> on <Date> was unexpected.» | F1-24 |
| 6009 | EventLog | «Microsoft (R) Windows (R) <OS Version>» (versión del SO registrada al arrancar). | F1-24 |
| 12 / 13 | Kernel-General | «The operating system started at system time …» / «The operating system is shutting down at system time …». | F1-24 |
| 1074 | User32 | «The process <Process Name> has initiated the restart of computer … on behalf of user …» con Reason Code y Shutdown Type. | F1-24 |
| 41 | Kernel-Power | «The system has rebooted without cleanly shutting down first.» | F1-24 |
| 7000 | Service Control Manager | En la consulta WEF figura junto a 7045 bajo el comentario «Service Install (7000), service start failure (7045)». **Ojo**: el comentario de esa consulta invierte los roles respecto de F1-24 (ver §10). | F1-15, F1-24 |
| **6006** | EventLog | **No verificado**: no se encontró página oficial que documente 6006 («The Event log service was stopped»). La documentación de reinicios sólo documenta 6005, 6008 y 6009. | F1-24 |
| **7040** | Service Control Manager | **No verificado**: no se encontró documentación oficial de 7040 (cambio de tipo de inicio de un servicio). | — |

### 4.5 PowerShell

| ID | Canal | Significado | Fuente |
| --- | --- | --- | --- |
| 4104 | Microsoft-Windows-PowerShell/Operational | Script Block Logging: «When Script Block Logging is enabled, PowerShell logs the following events… EventId `4104` / `0x1008`, Channel `Operational`, Level `Verbose`, Opcode `Create`, Task `CommandStart`, Keyword `Runspace`». | F1-17 |
| 4103 | Microsoft-Windows-PowerShell/Operational | Recolectado por la suscripción WEF «suspect»; el comentario oficial lo describe como «PowerShell execute block activity (4103)» (junto a 4105 Start Command y 4106 Stop Command). | F1-15 |
| 800 | Windows PowerShell (clásico) | «Legacy PowerShell pipeline execution details (800)». | F1-15 |
| 4104 (PS 7) | PowerShellCore/Operational | En PowerShell 7 el mismo ID se escribe en el canal **PowerShellCore/Operational**. | F1-18 |

Cómo se habilita el Script Block Logging:

| # | Hecho | Fuente |
| --- | --- | --- |
| 4.5.1 | «When you enable Script Block Logging, PowerShell records the content of all script blocks that it processes. Once enabled, any new PowerShell session logs this information.» | F1-17 |
| 4.5.2 | Por directiva (Windows PowerShell 5.1): activar **Turn on PowerShell Script Block Logging** en *Administrative Templates -> Windows Components -> Windows PowerShell*. | F1-17 |
| 4.5.3 | Por registro (5.1): `HKLM:\Software\Policies\Microsoft\Windows\PowerShell\ScriptBlockLogging`, valor `EnableScriptBlockLogging = "1"` (función `Enable-PSScriptBlockLogging` del propio documento). | F1-17 |
| 4.5.4 | En PowerShell 7 la ruta es `HKLM:\Software\Policies\Microsoft\PowerShellCore\ScriptBlockLogging` y la plantilla ADMX es *Administrative Templates -> PowerShell Core*. | F1-18 |
| 4.5.5 | Microsoft recomienda Protected Event Logging junto con Script Block Logging, porque el contenido registrado puede incluir credenciales u otros datos sensibles. | F1-17, F1-18 |
| 4.5.6 | Lectura de esos eventos: `Get-WinEvent Microsoft-Windows-PowerShell/Operational | Where-Object Id -EQ 4104` (ejemplo oficial, con `Unprotect-CmsMessage` si están cifrados). | F1-17 |
| 4.5.7 | La otra categoría es **Module logging** («Record the pipeline execution events for members of specified modules»), que debe habilitarse para la sesión y para cada módulo. | F1-18 |

### 4.6 RDP

| # | Hecho | Fuente |
| --- | --- | --- |
| 4.6.1 | **No verificado** en documentación oficial: los IDs 21 (Session logon succeeded), 24 (Session has been disconnected) y 25 (Session reconnection succeeded) del canal `Microsoft-Windows-TerminalServices-LocalSessionManager/Operational`, y el ID 1149 («User authentication succeeded») de `…-RemoteConnectionManager/Operational`. Sólo aparecen en hilos de Microsoft Q&A / foros archivados, que no son documentación. | F1-27 (no los documenta) |
| 4.6.2 | Sí está documentado que el canal `Microsoft-Windows-TerminalServices-RemoteConnectionManager` escribe en el registro **System** eventos como 1057/1058 (errores de certificado de RD Session Host). | F1-27 |
| 4.6.3 | Para rastrear sesiones RDP con fuente oficial, Microsoft usa el registro Security: 4624 con **Logon Type 10 (RemoteInteractive)**, más 4778/4779 (reconexión/desconexión de sesión) y, en el lado saliente, `Microsoft-Windows-TerminalServices-RDPClient/Operational` 1024. | F1-02, F1-01, F1-15 |

### 4.7 Sysmon (ver también §9)

Los IDs 1, 3, 5, 7, 8, 10, 11, 12, 13, 14, 22, 23 y 26 están documentados en F1-19; se detallan en la §9.

---

## 5. Tipos de inicio de sesión (Logon Type)

Tabla literal de F1-02 («Logon types and descriptions»); F1-03 repite la misma tabla como «Table 11: Windows Logon Types» para los valores 2–11.

| Valor | Título | Descripción (literal) | Fuente |
| --- | --- | --- | --- |
| 0 | System | «Used only by the System account, for example at system startup.» | F1-02 |
| 2 | Interactive | «A user logged on to this computer.» | F1-02, F1-03 |
| 3 | Network | «A user or computer logged on to this computer from the network.» | F1-02, F1-03 |
| 4 | Batch | «Batch logon type is used by batch servers, where processes can be run on behalf of a user without their direct intervention.» | F1-02, F1-03 |
| 5 | Service | «The Service Control Manager started a service.» | F1-02 |
| 7 | Unlock | «This workstation was unlocked.» | F1-02, F1-03 |
| 8 | NetworkCleartext | «A user logged on to this computer from the network. The user's password was passed to the authentication package in its unhashed form…» | F1-02, F1-03 |
| 9 | NewCredentials | «A caller cloned its current token and specified new credentials for outbound connections. The new logon session has the same local identity, but uses different credentials for other network connections.» | F1-02, F1-03 |
| 10 | RemoteInteractive | «A user logged on to this computer remotely using Terminal Services or Remote Desktop.» | F1-02, F1-03 |
| 11 | CachedInteractive | «A user logged on to this computer with network credentials that were stored locally on the computer. The domain controller wasn't contacted to verify the credentials.» | F1-02, F1-03 |
| 12 | CachedRemoteInteractive | «Same as RemoteInteractive. This type is used for internal auditing.» | F1-02 |
| 13 | CachedUnlock | «Workstation logon.» | F1-02 |

Recomendaciones asociadas: vigilar la discordancia entre tipo de inicio de sesión y cuenta («if **Logon Type** 4-Batch or 5-Service is used by a member of a domain administrative group»); para RDP con Restricted Admin, correlacionar `Logon Type = 10` con el campo **Restricted Admin Mode** (F1-02).

---

## 6. Política de auditoría: por defecto y recomendada

### 6.1 Diferencia entre política básica y avanzada

| # | Hecho | Fuente |
| --- | --- | --- |
| 6.1.1 | Hay **nueve** opciones básicas en *Security Settings\Local Policies\Audit Policy* y un conjunto más fino en *Security Settings\Advanced Audit Policy Configuration\System Audit Policies*; «they appear to overlap, but they're recorded and applied differently». | F1-13 |
| 6.1.2 | Ejemplo de granularidad: «the basic audit policy provides a single setting for account sign-in, and the advanced audit policy provides four. Enabling the single basic setting would be the equivalent of setting all four advanced settings». | F1-13 |
| 6.1.3 | Interacción: «Basic audit policy settings aren't compatible with advanced audit policy settings that are applied by using group policy. When advanced audit policy settings are applied by using group policy, the current computer's audit policy settings are cleared before the resulting advanced audit policy settings are applied». | F1-13 |
| 6.1.4 | Advertencia: «don't use both the basic audit policy settings… and the advanced settings… Using both advanced and basic audit policy settings can cause unexpected results in audit reporting». | F1-13 |
| 6.1.5 | Hay que habilitar **Audit: Force audit policy subcategory settings to override audit policy category settings** en *Local Policies\Security Options*: «This setting prevents conflicts between similar settings by forcing basic security auditing to be ignored». | F1-13 |
| 6.1.6 | Las categorías avanzadas son diez: Account Logon, Account Management, Detailed Tracking, DS Access, Logon/Logoff, Object Access, Policy Change, Privilege Use, System y Global Object Access Auditing. | F1-11 |
| 6.1.7 | Object Access exige además SACL en los objetos: «auditing isn't configured entirely unless a SACL has been configured for an object and a corresponding **Object Access** audit policy setting has been configured and applied». | F1-13 |
| 6.1.8 | Volver de avanzada a básica exige tres pasos (todo a «Not configured», borrar los `audit.csv` de `%SYSVOL%` en el DC y reconfigurar la básica); «Unless you complete all of these steps, the basic audit policy settings won't be restored». | F1-13 |
| 6.1.9 | Cambios de política de auditoría se detectan con la subcategoría *Audit Audit Policy Change* (y el evento 4719). | F1-13, F1-01 |

### 6.2 Qué trae habilitado Windows Server por defecto

Columna «Windows Default (Success | Failure)» de la pestaña **Windows Server** de F1-12. Celda vacía = sin recomendación/sin valor declarado en la tabla.

| Categoría | Subcategoría | Windows Default (Server) | Baseline (Server) | Stronger (Server) |
| --- | --- | --- | --- | --- |
| Account Logon | Audit Credential Validation | No \| No | Yes \| Yes | Yes \| Yes |
| Account Logon | Audit Kerberos Authentication Service | — | — | Yes \| Yes |
| Account Logon | Audit Kerberos Service Ticket Operations | — | — | Yes \| Yes |
| Account Logon | Audit Other Account Logon Events | — | — | Yes \| Yes |
| Account Management | Audit Computer Account Management | — | Yes \| DC | Yes \| Yes |
| Account Management | Audit Other Account Management Events | — | Yes \| Yes | Yes \| Yes |
| Account Management | Audit Security Group Management | — | Yes \| Yes | Yes \| Yes |
| Account Management | Audit User Account Management | **Yes \| No** | Yes \| Yes | Yes \| Yes |
| Detailed Tracking | Audit DPAPI Activity | — | — | Yes \| Yes |
| Detailed Tracking | Audit Process Creation | — (no por defecto) | Yes \| No | Yes \| Yes |
| DS Access | Audit Directory Service Access | — | DC \| DC | DC \| DC |
| DS Access | Audit Directory Service Changes | — | DC \| DC | DC \| DC |
| Logon/Logoff | Audit Account Lockout | **Yes \| No** | — | Yes \| No |
| Logon/Logoff | Audit Logoff | **Yes \| No** | Yes \| No | Yes \| No |
| Logon/Logoff | Audit Logon | **Yes \| Yes** | Yes \| Yes | Yes \| Yes |
| Logon/Logoff | Audit Network Policy Server | **Yes \| Yes** | — | — |
| Logon/Logoff | Audit Other Logon/Logoff Events | — | — | Yes \| Yes |
| Logon/Logoff | Audit Special Logon | **Yes \| No** | Yes \| No | Yes \| Yes |
| Object Access | (todas las subcategorías) | — | — | — |
| Policy Change | Audit Audit Policy Change | **Yes \| No** | Yes \| Yes | Yes \| Yes |
| Policy Change | Audit Authentication Policy Change | **Yes \| No** | Yes \| No | Yes \| Yes |
| Policy Change | Audit MPSSVC Rule-Level Policy Change | — | — | Yes |
| Privilege Use | (todas) | — | — | — |
| System | Audit IPsec Driver | — | Yes \| Yes | Yes \| Yes |
| System | Audit Other System Events | **Yes \| Yes** | — | — |
| System | Audit Security State Change | **Yes \| No** | Yes \| Yes | Yes \| Yes |
| System | Audit Security System Extension | — | Yes \| Yes | Yes \| Yes |
| System | Audit System Integrity | **Yes \| Yes** | Yes \| Yes | Yes \| Yes |

Leyenda oficial de la tabla: `Yes` = habilitar en escenarios generales; `No` = no habilitar; `If` = habilitar si el escenario/rol lo pide; `DC` = habilitar en controladores de dominio; en blanco = sin recomendación (F1-12).

| # | Hecho de contexto | Fuente |
| --- | --- | --- |
| 6.2.1 | «The default logging behavior in Windows systems *varies* by version and edition, with many audit-related Group Policy Objects (GPO) set to **Not Configured** by default.» | F1-01 |
| 6.2.2 | Consecuencia práctica: eventos como 4618 o 4649 «might require explicit audit policy configuration to be captured», mientras que 4719 suele registrarse por defecto. | F1-01 |
| 6.2.3 | Las recomendaciones de F1-12 son línea base SCM «intended only to be a starting baseline guide»; cada organización debe decidir y probar antes de producción. | F1-12 |
| 6.2.4 | Microsoft insiste en auditar también estaciones de trabajo: «Focusing solely on servers or domain controllers (DC) is a common oversight, as initial signs of malicious activity often appear on workstations». | F1-12 |
| 6.2.5 | **Audit Process Creation** (4688) no está habilitada por defecto ni en cliente ni en servidor: aparece en Baseline («Yes | No»), no en la columna Default. | F1-12 |
| 6.2.6 | Política mínima recomendada para alimentar una suscripción WEF (Apéndice A de F1-15): Credential Validation S+F; Security Group Management S; User/Computer/Other Account Management S+F; Process Creation S; Process Termination S; Logon S+F; Logoff S; Other Logon/Logoff S+F; Special Logon S+F; Account Lockout S; File Share S; Removable Storage S; Audit Policy Change S+F; MPSSVC/Other/Authentication/Authorization Policy Change S+F; Security State Change S+F; Security System Extension S+F; System Integrity S+F. | F1-15 |
| 6.2.7 | Criterios de alerta de Microsoft: un buen ID para alertar tiene «High likelihood that occurrence indicates unauthorized activity», pocos falsos positivos y obliga a investigar; se vigilan tanto eventos únicos como acumulaciones sobre la línea base. | F1-12 |
| 6.2.8 | Ejemplo explícito para este escenario: «Alert if an unauthorized service is installed on a DC». | F1-12 |

---

## 7. Borrado de registros: rastro, servicio detenido y MITRE

| # | Hecho | Fuente |
| --- | --- | --- |
| 7.1 | Borrar el registro Security deja **1102** con el SID, el nombre de cuenta, el dominio y el Logon ID del que lo borró. | F1-05 |
| 7.2 | Recomendación de Microsoft: «Typically you should not see this event. There is no need to manually clear the Security event log in most cases. We recommend monitoring this event and investigating why this action was performed.» | F1-05 |
| 7.3 | Borrar otros registros (System, Application, canales operativos) deja **104** en el registro correspondiente; la suscripción base de WEF lo recoge como «Other Log cleared events (104)». | F1-15 |
| 7.4 | Detener el servicio de registro de eventos deja **1100** en Security; Microsoft advierte: «This event also can be a sign of malicious action when someone tried to shut down the Log Service to cover his or her activity». Como 1100 también se genera en un apagado normal, hay que correlacionar con 6005/6006/12/13 del System. | F1-06, F1-24 |
| 7.5 | 1100 **no** se genera en un «emergency system reset» — hay borrados/cortes que no dejan ni ese rastro. | F1-06 |
| 7.6 | Llenar el registro a propósito (ruido) es otra vía: con retención «no sobrescribir», el registro lleno genera **1104**; con la configuración por defecto (sobrescribir) no hay evento y los antiguos simplemente desaparecen. | F1-07, F1-14 |
| 7.7 | MITRE **T1070.001 — Clear Windows Event Logs** (táctica Defense Evasion): los adversarios borran los registros para ocultar la intrusión; se hace con `wevtutil cl system`, `wevtutil cl application`, `wevtutil cl security` o con PowerShell (`Remove-EventLog -LogName Security`, `Clear-EventLog`). | F1-20 |
| 7.8 | Mitigaciones de T1070.001: **M1041** Encrypt Sensitive Information, **M1029** Remote Data Storage, **M1022** Restrict File and Directory Permissions. | F1-20 |
| 7.9 | Detección de T1070.001: vigilar ejecución de herramientas de borrado, llamadas a la API de eventos y creación de procesos con `wevtutil`/cmdlets de limpieza; indicadores clave: 1100, 1102 y 1104 en Security y 104 en System; «When an event log gets cleared, it is suspicious»; el reenvío centralizado dificulta borrar el rastro; analizar bloques de script (4104) en busca de `Clear-EventLog`. | F1-20 |
| 7.10 | MITRE **T1562.002 — Impair Defenses: Disable Windows Event Logging**: se deshabilita el registro para dejar menos evidencia, «to operate while leaving less evidence of a compromise behind»; vías: detener el servicio (`Set-Service -Name EventLog -Status Stopped`), modificar `HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\EventLog`, o usar `auditpol.exe` para desactivar categorías de auditoría. | F1-21 |
| 7.11 | Mitigaciones de T1562.002: **M1047** Audit (revisar `auditpol` en cuentas administrativas y establecer línea base en el SIEM), **M1022** Restrict File and Directory Permissions (sobre `C:\Windows\system32\Winevt\Logs`), **M1024** Restrict Registry Permissions, **M1018** User Account Management. | F1-21 |
| 7.12 | Detección de T1562.002: vigilar `wevtutil`, `auditpol`, `sc stop EventLog`, cambios de servicio y modificaciones de registro en las claves de EventLog, en particular `Start`, `File` y `MaxSize`. | F1-21 |
| 7.13 | Técnica relacionada documentada por MITRE en la versión actual del sitio: T1685.005 «Disable or Modify Tools: Clear Windows Event Logs» y T1685.001 «Disable or Modify Windows Event Log» (reorganización posterior a v14). **No verificado** su contenido: sólo se confirmó la existencia de las páginas por listado de búsqueda. | — |

---

## 8. Windows Event Forwarding (WEF / WEC)

| # | Hecho | Fuente |
| --- | --- | --- |
| 8.1 | «Windows Event Forwarding (WEF) reads any operational or administrative event logged on a device in your organization and forwards the events you choose to a Windows Event Collector (WEC) server.» | F1-15 |
| 8.2 | Modelo recomendado: dos suscripciones, **Baseline** (todos los equipos) y **Suspect/Targeted** (sólo equipos bajo sospecha, con «read existing events» en true para recoger lo ya registrado). | F1-15 |
| 8.3 | WEF es pasivo: «It can't change the size of event log files, enable disabled event channels, change channel permissions, or adjust a security audit policy. WEF only queries event channels for existing events.» Hay que habilitar la auditoría y los canales por GPO aparte. | F1-15 |
| 8.4 | Push vs pull: «A WEF subscription can be configured to be pushed or pulled, but not both.» Source-initiated (push) escala mejor; collector-initiated (pull) exige listar los equipos y dar acceso (normalmente añadiéndolos al grupo **Event Log Readers**). | F1-15 |
| 8.5 | Cifrado: en dominio «the connection used to transmit WEF events is encrypted using Kerberos, by default», con autenticación mutua, se use HTTP o HTTPS. | F1-15 |
| 8.6 | Para reenviar el registro Security: «To be able to forward the Security log you need to add the NETWORK SERVICE account to the EventLog Readers group.» | F1-16, F1-15 |
| 8.7 | Comandos base — en el equipo **origen**: `winrm qc -q` y la directiva *Computer Configuration → Administrative Templates → Windows Components → Event Forwarding → SubscriptionManager*, seguida de `gpupdate /force`. | F1-16 |
| 8.8 | Comandos base — en el **colector**: `winrm qc -q` y después `wecutil qc /q` («Run the following command to configure the Event Collector service»). Las suscripciones se crean con `wecutil cs configurationFile.xml`. | F1-16 |
| 8.9 | Verificación: `wecutil gr <subscriptionID>` (runtime status) y `wecutil gs <subscriptionID>` (configuración). | F1-16 |
| 8.10 | Formato de entrega: por defecto «Rendered Text»; el modo «Events» (XML binario) es más compacto y «can more than double the event volume a single WEC server can accommodate»: `Wecutil ss "testSubscription" /cf:Events`. | F1-15 |
| 8.11 | Modos de entrega integrados: Normal (pull, lotes de 5, timeout 15 min), Minimize Bandwidth (push, timeout y heartbeat de 6 h), Minimize Latency (push, timeout 30 s). | F1-15 |
| 8.12 | Límite de escala orientativo: «planning for a total of 3,000 events per second on average for all configured subscriptions» en hardware estándar. | F1-15 |
| 8.13 | Valor frente al borrado local: la suscripción base incluye explícitamente «Event log cleared (including the Security Event Log) — This event could indicate an intruder that is covering their tracks» y los eventos del servicio de registro de eventos (errores, arranque y parada). En XML: `Security` 1102/1100 y `System` 104. | F1-15 |
| 8.14 | Los eventos de Sysmon se pueden reenviar tal cual: la consulta base incluye `Path="Microsoft-Windows-Sysmon/Operational"` con `*`. | F1-15 |
| 8.15 | Además de WEF, Sysmon está pensado para eso: «By collecting the events it generates using Windows Event Collection or SIEM agents… you can identify malicious or anomalous activity». | F1-19 |

---

## 9. Sysmon

| # | Hecho | Fuente |
| --- | --- | --- |
| 9.1 | Qué es: «*System Monitor* (*Sysmon*) is a Windows system service and device driver that, once installed on a system, remains resident across system reboots to monitor and log system activity to the Windows event log.» | F1-19 |
| 9.2 | El servicio corre como proceso protegido, «thus disallowing a wide range of user mode interactions». No analiza los eventos ni se oculta del atacante. | F1-19 |
| 9.3 | Registra la línea de comandos completa del proceso y del padre, hashes (SHA1 por defecto; MD5, SHA256, IMPHASH o varios), ProcessGUID para correlacionar aunque se reutilicen PIDs, y arranca como boot-start driver para capturar actividad temprana. | F1-19 |
| 9.4 | Canal: `Applications and Services Logs/Microsoft/Windows/Sysmon/Operational`; marcas de tiempo en UTC. | F1-19 |
| 9.5 | Instalación (ejemplos literales): `sysmon -accepteula -i` (opciones por defecto) y `sysmon -accepteula -i c:\windows\config.xml` (con configuración). Uso general: `sysmon64 -i [<configfile>]`, `-c [<configfile>]` para actualizar/volcar configuración, `-m` manifiesto, `-s` esquema, `-u [force]` desinstalar. «Specify `-accepteula` to automatically accept the EULA on installation». Ni instalar ni desinstalar requieren reinicio. | F1-19 |
| 9.6 | Requisitos actuales de la versión publicada: «Client: Windows 11 and higher. Server: Windows Server 2019 and higher.» | F1-19 |

IDs principales (literal de F1-19):

| ID | Nombre | Nota |
| --- | --- | --- |
| 1 | Process creation | Información extendida, línea de comandos completa, ProcessGUID y hash. |
| 3 | Network connection | Conexiones TCP/UDP. **Deshabilitado por defecto**. |
| 5 | Process terminated | UtcTime, ProcessGuid, ProcessId. |
| 7 | Image loaded | Carga de módulos; deshabilitado por defecto («needs to be configured with the "–l" option»); genera mucho volumen. |
| 8 | CreateRemoteThread | Hilo creado en otro proceso: inyección de código. |
| 10 | ProcessAccess | Un proceso abre otro; permite detectar lectura de memoria de `lsass.exe` para robo de credenciales. |
| 11 | FileCreate | Creación/sobrescritura de archivos (útil en carpetas de arranque, temporales y descargas). |
| 12 | RegistryEvent (Object create and delete) | Creación/borrado de claves y valores. |
| 13 | RegistryEvent (Value Set) | Modificación de valores (registra el dato para DWORD y QWORD). |
| 14 | RegistryEvent (Key and Value Rename) | Renombrado de claves/valores. |
| 22 | DNSEvent (DNS query) | Consultas DNS del proceso; telemetría disponible desde Windows 8.1. |
| 23 | FileDelete (File Delete archived) | Archivo borrado **y** copiado al `ArchiveDirectory` (por defecto `C:\Sysmon`). |
| 26 | FileDeleteDetected (File Delete logged) | «A file was deleted» sin guardar copia. |

Complementos útiles para el escenario: 2 (cambio de fecha de creación de archivo, «technique commonly used by malware to cover its tracks»), 4 (cambio de estado del servicio Sysmon), 6 (driver cargado), 9 (RawAccessRead), 15 (FileCreateStreamHash), 16 (cambio de configuración de Sysmon), 17/18 (named pipes), 19/20/21 (WMI), 25 (ProcessTampering) — F1-19.

---

## 10. Contradicciones y cosas a vigilar

| # | Observación | Fuente |
| --- | --- | --- |
| 10.1 | **Tamaño por defecto**: el saber común dice «20 MB para todo». La documentación de directiva dice 20 MB sólo para **Security**; para Application y System el valor por defecto documentado es **1 MB**. Además, la salida de ejemplo de `Get-WinEvent -ListLog *` muestra Application con `MaximumSizeInBytes = 15532032` (≈14,8 MB) y varios canales con `1052672` (≈1 MB), lo que confirma que el valor real depende de la imagen y la configuración local. Conclusión: no afirmar un tamaño sin leerlo con `wevtutil gl` / `Get-WinEvent -ListLog`. | F1-14, F1-08 |
| 10.2 | **7045 vs 7000**: el comentario de la consulta WEF oficial dice «Service Install (7000), service start failure (7045)», mientras que la documentación de reinicios muestra el texto literal de 7045 como «A service was installed in the system». Prevalece F1-24 (texto del evento): 7045 = servicio instalado. | F1-15, F1-24 |
| 10.3 | **4103 vs 4104**: el comentario de la consulta WEF dice «PowerShell execute block activity (4103), Remote Command(4104)», mientras que la documentación de PowerShell define 4104 como el evento de Script Block Logging (Task `CommandStart`). Prevalece F1-17/F1-18 para 4104. | F1-15, F1-17 |
| 10.4 | **4697 no existe antes de Windows Server 2016**: «Minimum OS Version: Windows Server 2016, Windows 10». En equipos anteriores el rastro de servicio nuevo es 7045 en System. | F1-23, F1-24 |
| 10.5 | **1100 no siempre es malicioso**: se genera también en el apagado normal; hay que correlacionarlo con 6005/12/13 y con la hora de arranque. | F1-06, F1-24 |
| 10.6 | **La línea de comandos de 4688 está vacía por defecto**: sin la directiva «Include command line in process creation events», el 4688 no sirve para ver qué se ejecutó. | F1-04 |
| 10.7 | **Mezclar política básica y avanzada produce resultados inesperados**, y aplicar la avanzada por GPO **borra** la política vigente del equipo antes de aplicarla. | F1-13 |
| 10.8 | La columna «Windows Default» de F1-12 es de la tabla vigente (actualizada 2025-06-13) y no está segmentada por versión de Windows Server; para Windows Server 2019 concreto conviene verificarlo en el propio equipo con `auditpol /get /category:*`. | F1-12, F1-10 |

---

## 11. Puntos marcados «No verificado»

| Tema | Estado |
| --- | --- |
| RDP: IDs 21, 24, 25 (`TerminalServices-LocalSessionManager/Operational`) | **No verificado** en documentación oficial (sólo Q&A/foros archivados). |
| RDP: ID 1149 (`TerminalServices-RemoteConnectionManager/Operational`) | **No verificado** en documentación oficial. |
| System 6006 («The Event log service was stopped») | **No verificado**: la documentación de reinicios documenta 6005, 6008 y 6009, no 6006. |
| System 7040 (cambio de tipo de inicio de servicio) | **No verificado**: sin página oficial encontrada. |
| Reorganización MITRE T1685.001 / T1685.005 | **No verificado** (existencia constatada por listado, contenido no leído). |
| Tabla completa de IDs de Windows Server 2019 con texto por versión | **No verificado** como página web; Microsoft remite al descargable «Windows security audit events» (`microsoft.com/download/details.aspx?id=50034`) y a `wevtutil gp Microsoft-Windows-Security-Auditing /ge /gm:true`. |
