dotnet clean src --verbosity minimal
dotnet restore src
dotnet build src --no-restore -c Release
dotnet test src --no-build -c Release