| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-10-26 |
| Autor | Presidencia de la mesa |
| Corrige | — |

# Providencia — autenticación con el sistema operativo y manejo de red, en la demo

```testimonio
tuviste en cuenta algunos detalles basicos: manejo de autentificación usando los mecanismos configurados en el sistema operativo, manejo de red (detección de corte de internet, notificación al usuario que no hay red, y reconexión automatica) con bloqueo de acciones que requieren internet ? - la mesa lo planteo , sino hacelo
```

| Canal | Fecha-hora | Huella |
| --- | --- | --- |
| Chat de Claude Code en VS Code | 2026-10-26T09:20-03:00 | `75deadb441c4dc15525f62033f52c33ab58aac9f86a7d1c3f24086aef05b8479` |

## Lo que la mesa ya había decidido y lo que falta

| Tema | Mesa | Demo construida (tramos A1–A3) |
| --- | --- | --- |
| Autenticación con los mecanismos del SO | Decidida para el framework en P4 (folio 035): OIDC code + PKCE en el navegador del sistema; desbloqueo local con Keystore (`setUserAuthenticationParameters`, API ≥ 30) / Keychain `userPresence`; entrada local separada de la sesión; outbox con dueño; D-03 = T1 | **Fuera del mínimo** por decisión del jurado (folio 035 «Decisión para la demo»: sin IdP) |
| Detección de corte, aviso al usuario y reconexión automática | Borrador del PO §6 (estados SinRed / RedSinServidor / EnLinea / EnLineaMedida, chequeo de salud propio); P2 y P5 lo usan | Parcial: `Connectivity` + evento `network.changed` + reintento del sincronizador; **sin** chequeo de salud, sin aviso permanente al usuario |
| Bloqueo de acciones que requieren internet | Borrador §7 (clases SoloLocal / Encolable / SoloEnLinea, SoloWiFi opcional); el dictamen nombra las Encolable (P4, P5) | **No implementado** como política visible |

## Efecto

Es una **aprobación de alcance** de quien pidió: P4 y la política de red del borrador (§6 y §7) **entran en la demo**.
Sustituye, para la demo, la «Decisión para la demo» de P4 del folio 035. El diseño ya está decidido (P4 del folio 035
y el borrador §6–§7); no se convoca mesa. Se aplica como un incremento de la demo:

1. Estado de red combinado (`Connectivity` + chequeo de salud del servidor con caché corta), con evento al contenido,
   aviso permanente y visible en la interfaz y reconexión automática que reanuda la sincronización.
2. Política de acciones declarada por acción (SoloLocal, Encolable, SoloEnLinea) evaluada por el cascarón; la interfaz
   deshabilita lo bloqueado y dice por qué.
3. Autenticación: primer ingreso OIDC code + PKCE contra un emisor de ensayo (Keycloak en contenedor, accesible por
   la red privada); refresh token protegido por una clave del Keystore atada a la autenticación del dispositivo
   (huella, rostro, PIN o patrón); ingresos siguientes con la seguridad del teléfono; si falla o se revoca, vuelve al
   ingreso con cuenta; cerrar sesión borra tokens y clave sin borrar pendientes de otro dueño (P4).

Sigue: incremento de la demo (diseño fino, red, autenticación, integración en el emulador de hpdev, revisión) · presidencia · Cierra con: informe de integración del incremento
