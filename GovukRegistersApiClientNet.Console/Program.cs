using GovukRegistersApiClientNet.Factories;
using GovukRegistersApiClientNet.Services;
using System;

namespace GovukRegistersApiClientNet.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var client = RegisterClientFactory.CreateRegisterClientAsync("country", Enums.Phase.ReadyToUse, new InMemoryDataStore(), new RsfDownloadService(), new RsfUpdateService(new Sha256Service())).GetAwaiter().GetResult();
            var records = client.GetRecords();

            Console.WriteLine(records);
            Console.ReadLine();
        }
    }
}
