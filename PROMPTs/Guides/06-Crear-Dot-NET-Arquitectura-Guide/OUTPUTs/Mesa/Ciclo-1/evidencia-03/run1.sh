set -x
cd /w
dotnet --version
dotnet new sln -n Ciclo -o ciclo >/dev/null && ls ciclo
cd ciclo
dotnet new classlib -n A.Domain >/dev/null; dotnet new classlib -n A.Infra >/dev/null
dotnet add A.Infra reference A.Domain
dotnet add A.Domain reference A.Infra; echo "exit add: $?"
dotnet build A.Domain 2>&1 | tail -5
