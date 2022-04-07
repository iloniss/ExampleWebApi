# ExampleWebApi
Aby uruchomić aplikację należy:
- ustawić w ConnectionStrings nazwę serwera w pliku **appsettings.json** w projekcie **ExampleWebApi.API**
- zaktualizować bazę danych w projekcie **ExampleWebApi.INFRASTRUCTURE** za pomocą polecenia
`dotnet ef database update --startup-project ../ExampleWebApi/ExampleWebApi.API.csproj`

Aplikację można testować za pomocą Swagger.
