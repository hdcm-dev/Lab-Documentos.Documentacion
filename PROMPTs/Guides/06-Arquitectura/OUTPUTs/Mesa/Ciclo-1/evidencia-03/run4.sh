cd /tmp
dotnet new list 2>/dev/null | grep -iE "blazor|razor|maui|webapi|sln" 
dotnet new blazorwasm -n W >/dev/null 2>&1; find W -name "appsettings*.json"; grep -n "Swash\|OpenApi" -r W/*.csproj
dotnet new webapi -n A >/dev/null 2>&1; grep -n "PackageReference" A/A.csproj
