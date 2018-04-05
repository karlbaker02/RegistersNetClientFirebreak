using GovukRegistersApiClientNet.Factories;
using GovukRegistersApiClientNet.Services;
using System;
using System.Linq;

namespace GovukRegistersApiClientNet.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var client = RegisterClientFactory.CreateRegisterClientAsync("country", Enums.Phase.ReadyToUse, new InMemoryDataStore(), new RsfDownloadService(), new RsfUpdateService(new Sha256Service())).GetAwaiter().GetResult();
            var records = client.GetRecords().ToList();

            foreach (var record in records)
            {
                var entry = record.GetEntry();
                var itemData = record.GetItem().Json;
                Console.WriteLine($"{entry.EntryNumber} {entry.Key} {itemData["name"]}");
            }

            Console.ReadLine();
        }
    }
}
