| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-10-25 |
| Autor | Presidencia de la mesa |
| Corrige | — |

# Providencia — delegación del merge para conformar los pull requests

```testimonio
acordate de seguir este conocimiento `<base de conocimiento>/Knowledges/Knowledge-Conformacion-Pull-Request-Automatico.md` para conformar los pR
```

| Canal | Fecha-hora | Huella |
| --- | --- | --- |
| Chat de Claude Code en VS Code | 2026-10-25T20:20-03:00 | `1c5bba9ed2ec0031bb22be83afd5e497379b6b61414bd95f0e9cf95aa8439fb4` |

## Clasificación

Es una **aprobación** con decisión del responsable del producto: los pull requests de esta corrida se conforman
con `Conformacion-Pull-Request-Automatico` 2.0. El agente abre el PR, publica el informe con el enlace, fusiona
con commit de merge atado a la cabeza auditada, borra la rama remota y deja el local en orden. La delegación queda
asentada con fecha y responsable (§3.1 de ese conocimiento) en este folio, y al entregar se copia a la carta de
cambios de cada repositorio destino (`Lab-Documentos`, `Lab-Documentos.Documentacion`).

## Parámetros de la delegación

| Parámetro | Valor | Origen |
| --- | --- | --- |
| Alcance | Los PR de esta corrida (expediente 0001) en `hdcm-dev/Lab-Documentos` y `hdcm-dev/Lab-Documentos.Documentacion` | Pedido + folio 001 |
| Techo de espera de la guarda | 60 minutos | **Agregado de la presidencia**: el PO no lo fijó. SI NO RESPONDÉS: rige 60 min |
| Intervalo de relectura | 30 segundos | **Agregado de la presidencia**. SI NO RESPONDÉS: rige 30 s |
| Excepción | Un cuestionamiento particular del PO sobre la unidad la vuelve manual (§3.4) | Forma observada del conocimiento |
| Método de merge | Commit de merge, nunca `squash`: la rama lleva un expediente (§3.5) | Conocimiento |

## Reservas previsibles

- `main` de `Lab-Documentos` no tiene protección de rama (informe de la comisión de integración, H-02). La
  guarda G3 exige al menos una corrida de controles en éxito para la cabeza: sin workflow que corra sobre el PR,
  es reserva.
- `Lab-Documentos.Documentacion` tiene cambios del PO sin confirmar (ia-db y prompts de indexado): el PR lleva
  sólo las rutas de esta corrida y se trabaja en un `git worktree` propio, para no arrastrar ni pisar ese árbol.
- El testimonio del folio 004 nombra un repositorio privado en un repositorio público (S2): se resuelve antes del
  push o queda como reserva.

Sigue: veredicto del jurado, resolución, construcción de la demo y la guía, y entrega por PR con este ciclo · presidencia · Cierra con: cierre del ciclo publicado por cada PR
