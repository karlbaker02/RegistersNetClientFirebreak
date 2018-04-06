using GovukRegistersApiClientNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovukRegistersApiClientNet.ConsoleApp
{
    public class CountryRegisterTestService
    {
        private readonly IRegisterClient _registerClient;

        public CountryRegisterTestService(IRegisterClient registerClient)
        {
            _registerClient = registerClient;
        }

        public void PrintCountryData()
        {
            var records = _registerClient.GetRecords().ToList();

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
