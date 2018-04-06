using GovukRegistersApiClientNet.Implementation;
using GovukRegistersApiClientNet.Implementation.Extensions;
using GovukRegistersApiClientNet.Implementation.Interfaces;
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

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddRegistersApiClient();
        }
    }
}
