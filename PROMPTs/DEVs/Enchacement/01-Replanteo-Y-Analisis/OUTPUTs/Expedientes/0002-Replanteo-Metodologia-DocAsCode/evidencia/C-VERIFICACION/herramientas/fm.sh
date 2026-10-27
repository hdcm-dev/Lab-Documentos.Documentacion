#!/bin/sh
# uso: fm.sh <carpeta-del-corpus>   (corre dentro del contenedor node)
npx --no-install remark --frail --quiet --no-stdout "$1" 2>&1 | grep -v 'npm notice' | sed 's/\x1b\[[0-9;]*m//g'
