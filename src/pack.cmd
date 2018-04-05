rmdir build /S /Q
dotnet pack NHibernate.Mapping.Attributes\NHibernate.Mapping.Attributes.csproj --include-symbols --include-source --configuration release -o ..\build\