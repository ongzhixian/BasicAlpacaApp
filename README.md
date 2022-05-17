# BasicAlpacaApp

A basic .NET Core Alpaca console application use for simple deployments in Kubernetes.


```ps1: In C:\src\github.com\ongzhixian\BasicAlpacaApp
dotnet new sln -n BasicAlpacaApp
dotnet new console -n BasicAlpacaApp.ConsoleApp
dotnet sln .\BasicAlpacaApp.sln add .\BasicAlpacaApp.ConsoleApp\


dotnet add .\BasicAlpacaApp.ConsoleApp\ package Microsoft.Extensions.Configuration
dotnet add .\BasicAlpacaApp.ConsoleApp\ package Microsoft.Extensions.Configuration.UserSecrets
--dotnet add .\BasicAlpacaApp.ConsoleApp\ package Microsoft.Extensions.Configuration.Json

dotnet add .\BasicAlpacaApp.ConsoleApp\ package Alpaca.Markets
dotnet add .\BasicAlpacaApp.ConsoleApp\ package Alpaca.Markets.Extensions

dotnet user-secrets --project .\BasicAlpacaApp.ConsoleApp\ init
dotnet user-secrets --project .\BasicAlpacaApp.ConsoleApp\ set "alpaca:paper:apiKeyId" "<api-key-id>"
dotnet user-secrets --project .\BasicAlpacaApp.ConsoleApp\ set "alpaca:paper:secretKey" "<secret-key>"

```


Other ways to extend configuration

```

Microsoft.Extensions.Configuration.CommandLine 
Microsoft.Extensions.Configuration.Binder 
Microsoft.Extensions.Configuration.EnvironmentVariables
```
