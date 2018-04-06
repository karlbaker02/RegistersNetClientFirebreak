param([string]$NugetApiKey)

nuget setApiKey $NugetApiKey

dotnet pack GovukRegistersApiClientNet -c Release --include-symbols
dotnet pack GovukRegistersApiClientNet.Implementation -c Release --include-symbols

(Get-Content "Directory.Build.props") | ForEach-Object{
    if($_ -match "<Version>(.*)</Version>"){
        $clientVersion = $matches[1]

		nuget push .\GovukRegistersApiClientNet\bin\Release\GovukRegistersApiClientNet.$clientVersion.nupkg $NugetApiKey -Source https://api.nuget.org/v3/index.json
		nuget push .\GovukRegistersApiClientNet.Implementation\bin\Release\GovukRegistersApiClientNet.Implementation.1.1.0.nupkg $NugetApiKey -Source https://api.nuget.org/v3/index.json
	}
}