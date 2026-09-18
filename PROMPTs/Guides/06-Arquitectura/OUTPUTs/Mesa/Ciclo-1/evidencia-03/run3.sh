cd /w/g/Api
python3 - 2>/dev/null || true
# quitar la clase ProductoApiService para ver los demás errores
awk '/^public class ProductoApiService/{skip=1} skip&&/^}/{skip=0;next} !skip' Guia.cs > t && mv t Guia.cs
dotnet build 2>&1 | grep -E "error" | sed 's#/w/g/Api/##' | sort -u
