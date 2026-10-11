#!/bin/sh
# x4 (auditor ciclo 3): el guardián propuesto para §5.2.6 paso 5, pegado en un bash interactivo,
# con un cambio sin commitear (debe avisar y dejar la terminal abierta) y con el árbol limpio.
set -u
R=$(mktemp -d); cd "$R" && git init -q -b main . && git -c user.email=a@b -c user.name=a commit -q --allow-empty -m base
echo x > sucio.txt && git add sucio.txt
BLOQUE='if git diff --quiet && git diff --cached --quiet; then
  git pull --ff-only && git rm -rq --cached . && git reset -q --hard
else
  echo "commiteá o guardá con git stash antes de seguir" >&2
fi
echo "la terminal sigue abierta"'
echo "-- árbol sucio:"; printf '%s\n' "$BLOQUE" | env -i PATH="$PATH" HOME=/tmp LANG=C.UTF-8 bash --norc -i 2>&1 | grep -v '^bash: \|^\$ \|^exit$' ; echo "estado del shell interactivo: $?"
git reset -q --hard; git rm -q --cached sucio.txt 2>/dev/null; rm -f sucio.txt
echo "-- árbol limpio (sin remoto: git pull falla y no se ejecuta lo que sigue):"; printf '%s\n' "$BLOQUE" | env -i PATH="$PATH" HOME=/tmp LANG=C.UTF-8 bash --norc -i 2>&1 | grep -v '^bash: \|^\$ \|^exit$'
