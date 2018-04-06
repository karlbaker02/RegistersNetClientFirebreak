Set-Variable -Name "NugetApiKey" -Value "NUGET_API_KEY_HERE"

dotnet pack GovukRegistersApiClientNet -c Release --include-symbols
dotnet pack GovukRegistersApiClientNet.Implementation -c Release --include-symbols

