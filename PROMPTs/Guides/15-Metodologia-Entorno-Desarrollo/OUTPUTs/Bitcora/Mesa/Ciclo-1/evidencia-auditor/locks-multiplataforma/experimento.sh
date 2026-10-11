#!/bin/sh
# C1-58: ¿pnpm-lock.yaml y yarn.lock registran las variantes de otras plataformas?
set -u
node -v; npm -v
npm i -g pnpm@10.18.0 >/dev/null 2>&1; echo "pnpm $(pnpm -v)"
mkdir -p /tmp/p && cd /tmp/p && printf '{"name":"p","version":"1.0.0","private":true,"dependencies":{"esbuild":"0.25.10"}}\n' > package.json
pnpm install --ignore-scripts >/dev/null 2>&1; echo "pnpm install rc=$?"
echo "entradas @esbuild/win32-x64 en pnpm-lock.yaml: $(grep -c "'@esbuild/win32-x64@0.25.10'" pnpm-lock.yaml)"
grep -A3 "^  '@esbuild/win32-x64@0.25.10':" pnpm-lock.yaml | head -4
echo "plataformas en el lock: $(grep -c "^  '@esbuild/.*@0.25.10':" pnpm-lock.yaml)"
echo "instaladas: $(ls node_modules/.pnpm | grep '^@esbuild' | tr '\n' ' ')"
cd / && mkdir -p /tmp/y && cd /tmp/y && printf '{"name":"y","version":"1.0.0","private":true,"packageManager":"yarn@4.10.3","dependencies":{"esbuild":"0.25.10"}}\n' > package.json
corepack enable >/dev/null 2>&1; COREPACK_ENABLE_DOWNLOAD_PROMPT=0 yarn --version
COREPACK_ENABLE_DOWNLOAD_PROMPT=0 YARN_ENABLE_SCRIPTS=0 YARN_NODE_LINKER=node-modules yarn install >/dev/null 2>&1; echo "yarn install rc=$?"
grep -A8 '"@esbuild/win32-x64@npm:0.25.10"' yarn.lock | grep -E 'esbuild/win32-x64|conditions'
echo "plataformas en el lock: $(grep -c '^"@esbuild/.*@npm:0.25.10"' yarn.lock)"
echo "instaladas: $(ls node_modules/@esbuild | tr '\n' ' ')"
