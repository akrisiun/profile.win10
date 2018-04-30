dotnet build iis.csproj -o bin

if (test-path -path "obj") {
   del obj/* -force -recurse
}
dotnet restore dotnet/dotnet-iis.csproj
dotnet build   dotnet/dotnet-iis.csproj -o .