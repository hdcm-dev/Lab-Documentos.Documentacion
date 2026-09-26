cd /w
curl --version | head -1; echo "curl exit: $?"
rm -rf t && mkdir t && cd t
dotnet new classlib -n X.Domain >/dev/null; dotnet new classlib -n X.Infra >/dev/null
cat > X.Infra/Repo.cs <<'C'
namespace X.Infra; public class Repo {}
C
cat > X.Domain/Uso.cs <<'C'
using X.Infra;
namespace X.Domain; public class Uso { public Repo? R; }
C
dotnet build X.Domain 2>&1 | grep -E "error CS" | sed 's#/w/t/##' | sort -u | head
