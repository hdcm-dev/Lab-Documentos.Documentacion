| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-30 |
| Autor | Presidencia de la mesa |
| Sigue a | 052 |

# Constancia — V1S: la semilla del APK no alcanza para el primer arranque

## Hecho

- El PO aprobó la semilla de fábrica firmada dentro del APK y el paso de V1 a `main` («aprobado», 2026-10-30). La mesa
  midió primero V1S, V1 más la semilla servida desde el APK con la firma verificada, en una rama descartable. Detalle
  en `Ensayos/E04-Arranque-Superpuesto/INFORME.md`, sección V1S.
- **Primer arranque recién instalado**: 8 783, 7 930 y 8 572 ms (V1: 9 648). **Régimen**: 5 554 · 5 064 · 4 893 ·
  4 953 ms, igual que V1.
- La semilla se sirve desde los 3,5–4,2 s, pero el saludo del contenido llega a los 6,4–7,7 s, porque Mono arranca más
  lento en el primer uso tras instalar. Además, el cascarón lo retiene hasta que el actualizador decide, a los 7,5–8,3 s.

## Consecuencia

- Con este modelo, la corrida recién instalada no baja de 5 s en el g42.
- El método de P1 dice «con el contenido ya instalado» (035:325-337). Contar o no la corrida recién instalada es lo que
  decide el veredicto. Sin ella, V1 queda en el borde: entre 4,8 y 5,6 s según la serie.
- El paso de V1 a `main` queda en espera: la mesa no lo hace hasta que el PO resuelva el punto 1, porque V1 trae el
  hallazgo abierto de la pantalla en blanco (052, revisión).

## Lo que decide el PO

1. Si la corrida recién instalada cuenta para el umbral de P1. El método dice «con el contenido ya instalado».
2. Si V1 se incorpora a `main` de todos modos, con la salvaguarda de la pantalla en blanco que la revisión dejó
   abierta.
3. Si se revisa el umbral, por ejemplo 5 s en régimen y un tope aparte para el primer arranque, o si se mide el
   control C-min.

## Pase

Al PO. El expediente sigue ARCHIVADO.
