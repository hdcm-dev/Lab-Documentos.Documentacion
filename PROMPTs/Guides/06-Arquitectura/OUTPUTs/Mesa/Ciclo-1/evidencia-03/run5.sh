cd /tmp; dotnet new blazorwasm -n W 2>&1 | tail -2; find W -maxdepth 2 | grep -v obj | sort
dotnet new blazor -h 2>/dev/null | grep -iA6 "interactivity"
