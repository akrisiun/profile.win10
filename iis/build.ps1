dotnet build net46/iis.csproj -o .

del obj/* -force -recurse
dotnet restore dotnet/dotnet-iis.csproj
dotnet build   dotnet/dotnet-iis.csproj -o .