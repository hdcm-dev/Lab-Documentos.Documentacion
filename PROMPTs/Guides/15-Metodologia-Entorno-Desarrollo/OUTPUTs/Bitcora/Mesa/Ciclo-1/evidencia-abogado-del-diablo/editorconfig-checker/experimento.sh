#!/bin/sh
# Abogado del diablo, ciclo 1. ¿Una herramienta existente detecta lo mismo que check_text_policy.py?
# Uso: sh experimento.sh   (necesita docker; crea ./repo y escribe ./salida.txt)
set -u
rm -rf repo && mkdir repo && cd repo
cat > .editorconfig <<'EC'
root = true

[*]
charset = utf-8
end_of_line = lf
insert_final_newline = true

[*.{razor,cshtml,sln}]
charset = utf-8-bom
EC
printf 'class A { string s = "Atenci\363n"; }\n' > Cp1252.cs        # byte F3 = ó en cp1252
printf 'class B { string s = "Atenci\303\263n"; }\n' > Utf8.cs      # UTF-8 sin BOM: válido
printf '\357\273\277class C { }\n' > ConBom.cs                       # BOM donde la política dice utf-8
printf '<p>Atenci\303\263n</p>\n' > SinBom.razor                     # falta el BOM que pide la política
printf '\357\273\277<p>Atenci\303\263n</p>\n' > ConBom.razor          # válido
printf '\357\273\277{ "a": 1 }\n' > conbom.json                      # BOM indebido
printf 'echo hola\r\n' > crlf.sh                                     # CRLF indebido
docker run --rm --volume="$PWD":/check ghcr.io/editorconfig-checker/editorconfig-checker:4.0.2 > ../salida.txt 2>&1
rc=$?; sed -i "s/\x1b\[[0-9;]*m//g" ../salida.txt; echo "rc=$rc" >> ../salida.txt
cat ../salida.txt
