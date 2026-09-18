set -x
dotnet --version
cd /w && rm -rf Tienda && mkdir Tienda && cd Tienda
dotnet new sln -n Tienda
dotnet new classlib -n Tienda.Domain -o src/Tienda.Domain
dotnet new classlib -n Tienda.Infrastructure -o src/Tienda.Infrastructure
dotnet sln add src/Tienda.Domain src/Tienda.Infrastructure
dotnet add src/Tienda.Infrastructure reference src/Tienda.Domain
dotnet add src/Tienda.Domain reference src/Tienda.Infrastructure
dotnet build 2>&1 | tail -8
