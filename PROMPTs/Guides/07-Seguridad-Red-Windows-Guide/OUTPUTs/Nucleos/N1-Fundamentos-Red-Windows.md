---
doc_id: N1
doc_type: nucleo
title: N1 — Fundamentos de una red Windows
status: vigente
traces: [BIT-02-NUCLEOS, ESC-TESTIGO]
---

# N1 — Fundamentos de una red Windows

**Pregunta que resuelve:** ¿qué es exactamente lo que estoy auditando?

## Ideas agrupadas
- Red, dirección IP, puerto, protocolo (TCP/UDP) — vocabulario mínimo de red (RFC 791/768/9293; rangos de puertos IANA).
- Dominio, Active Directory, controlador de dominio, DNS interno.
- Protocolos que importan en el caso: SMB (445), RDP (3389), Kerberos (88), LDAP (389).
- Cuentas: usuario, cuenta de servicio, grupo, SID, privilegio.
- Qué es un *logon* y por qué tiene "tipos" (interactivo, de red, remoto).
- Línea de base: qué es "lo normal" contra lo que se compara lo anómalo.

## Dependencias
Prerrequisito de todos los demás núcleos. No depende de ninguno.

## Evidencia que usa
Puertos y roles de un DC (Microsoft Learn, requisitos de puertos de servicio); definición de socket y estados TCP (RFC 9293).

## Mapa a la guía
Secciones 1 y 2. Aporta el glosario que el resto referencia.
