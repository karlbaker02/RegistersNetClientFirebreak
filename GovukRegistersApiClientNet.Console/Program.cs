using GovukRegistersApiClientNet.Implementation;
using GovukRegistersApiClientNet.Implementation.Factories;
using GovukRegistersApiClientNet.Implementation.Services;
using System;
using System.Linq;

namespace GovukRegistersApiClientNet.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var client = RegisterClientFactory.CreateRegisterClientAsync("country", Enums.Phase.ReadyToUse, new InMemoryDataStore(), new RsfDownloadService(), new Implementation.Services.RsfUpdateService(new Sha256Service())).GetAwaiter().GetResult();
            var records = client.GetRecords().ToList();

            foreach (var record in records)
            {
                var entry = record.Entry;
                var itemData = record.Item.Data;
                Console.WriteLine($"{entry.EntryNumber} {entry.Key} {itemData["name"]}");
            }

            Console.ReadLine();
        }
    }
}
