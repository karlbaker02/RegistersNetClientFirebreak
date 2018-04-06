using GovukRegistersApiClientNet.Enums;
using GovukRegistersApiClientNet.Implementation.Interfaces;
using System.Threading.Tasks;

namespace GovukRegistersApiClientNet.Implementation.Factories
{
    public class RegisterClientFactory : IRegisterClientFactory
    {
        private readonly IRsfDownloadService _rsfDownloadService;
        private readonly IRsfUpdateService _rsfUpdateService;

        public RegisterClientFactory(IRsfDownloadService rsfDownloadService, IRsfUpdateService rsfUpdateService)
        {
            _rsfDownloadService = rsfDownloadService;
            _rsfUpdateService = rsfUpdateService;
        }

        public Task<RegisterClient> CreateRegisterClientAsync(
            string register,
            Phase phase,
            IDataStore dataStore)
        {
            var client = new RegisterClient(register, phase, dataStore, _rsfDownloadService, _rsfUpdateService);
            return InitializeAsync(client);
        }

        private static async Task<RegisterClient> InitializeAsync(RegisterClient client)
        {
            await client.RefreshData();
            return client;
        }
    }
}
