using GovukRegistersApiClientNet.Enums;
using GovukRegistersApiClientNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GovukRegistersApiClientNet.Factories
{
    public class RegisterClientFactory
    {
        public static Task<RegisterClient> CreateRegisterClientAsync(
            string register, 
            Phase phase, 
            IDataStore dataStore, 
            IRsfDownloadService rsfDownloadService, 
            IRsfUpdateService rsfUpdateService)
        {
            var client = new RegisterClient(register, phase, dataStore, rsfDownloadService, rsfUpdateService);
            return InitializeAsync(client);           
        }

        private static async Task<RegisterClient> InitializeAsync(RegisterClient client)
        {
            await client.RefreshData();
            return client;
        }
    }
}
