#!/bin/sh
# Compara la copia vendorizada con el upstream en el commit del manifiesto. exit 1 si difiere.
# uso: deriva-vendor.sh <dir-vendor> <clon-upstream>
V=$1; U=$2; C=$(sed -n 's/^commit: //p' $V/MANIFIESTO.txt); rc=0
grep -E '^[0-9a-f]{64}  ' $V/MANIFIESTO.txt | while read h p; do a=$(sha256sum "$V/$p" | cut -c1-64); b=$(git -C "$U" show "$C:$p" | sha256sum | cut -c1-64); [ "$a" = "$h" ] && [ "$b" = "$h" ] || { echo "DERIVA $p"; echo x >> /tmp/deriva.$$; }; done
[ -f /tmp/deriva.$$ ] && { rm -f /tmp/deriva.$$; exit 1; }; echo "sin deriva contra $C"; exit 0
