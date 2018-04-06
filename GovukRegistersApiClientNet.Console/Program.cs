using GovukRegistersApiClientNet.Implementation;
using GovukRegistersApiClientNet.Implementation.Factories;
using GovukRegistersApiClientNet.Implementation.Interfaces;
using GovukRegistersApiClientNet.Implementation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GovukRegistersApiClientNet.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();

            var factory = provider.GetService<IRegisterClientFactory>();
            var registerClient = factory.CreateRegisterClientAsync("country", Enums.Phase.ReadyToUse, new InMemoryDataStore()).GetAwaiter().GetResult();
            var countryRegisterTestService = new CountryRegisterTestService(registerClient);

            countryRegisterTestService.PrintCountryData();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDataStore, InMemoryDataStore>();
            services.AddSingleton<IRsfDownloadService, RsfDownloadService>();
            services.AddSingleton<IRsfUpdateService, RsfUpdateService>();
            services.AddSingleton<ISha256Service, Sha256Service>();
            services.AddSingleton<IRegisterClientFactory, RegisterClientFactory>();
        }
    }
}
