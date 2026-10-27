# E-A01 — Regla de largo del nombre de localidad: declarado vs. aplicado (MovilidadUrbana.MAUI)

Método: copia de 7 archivos de /LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor/src/MovilidadUrbana.MAUI (commit 8fb4c3a) a un directorio de trabajo fuera del repo; consola net10.0 con repositorio en memoria + EF Core SQLite 10.0.11 en memoria con HasMaxLength(60) (réplica de Infrastructure/Persistence/AppDbContext.cs:28).
Comando: docker run --rm -v <trabajo>:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 sh -c 'dotnet run -c Release'
Fecha-hora: 2026-10-26T15:08-03:00 · Quién: comisión C-ANALISTA

Huellas sha256 (16) de las copias:
```
0bbcf2506d1dbd8e
73ddb8dea26a3778
e316989964dcac6d
dd8cf6960c1b01e9
6f245f4eca4ff5e8
986f415dbda65c64
be734129e796afaa
```

Salida:
```
Requisito mostrado a la persona: «Entre 3 y 60 caracteres, único por provincia.»
largo=  2 -> IsSuccess=False El nombre debe tener al menos 3 caracteres.
largo=  3 -> IsSuccess=True Se agregó la localidad aa3.
largo= 60 -> IsSuccess=True Se agregó la localidad aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa0.
largo= 61 -> IsSuccess=True Se agregó la localidad aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa1.
largo= 80 -> IsSuccess=True Se agregó la localidad aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa0.
SQLite guardó nombre de 80 caracteres con HasMaxLength(60)
```

Anclas leídas: LocalidadPolicy.cs:15-16 (requisito mostrado), LocalidadRules.cs:11-12 y :18-19 (NombreValido sólo controla el mínimo), LocalidadService.cs:72-78 (Validate), Pages/LocalidadEditorPage.xaml:22 (MaxLength="80"); Web: Components/Pages/Localidades.razor:49 (maxlength=@LocalidadRules.LargoMaximoDelNombre). Sin prueba que verifique el máximo: grep de 'Largo|60|Maximo' en tests/MovilidadUrbana.UnitTests/LocalidadRulesTests.cs, tests/MovilidadUrbana.MAUI.Tests/LocalidadEditorViewModelTests.cs y tests/MovilidadUrbana.ApiWeb.Tests/*.cs: 0 coincidencias.
