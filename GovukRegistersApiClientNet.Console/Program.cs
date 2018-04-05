using System;

namespace GovukRegistersApiClientNet.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var client = new RegisterClient("country", Enums.Phase.ReadyToUse, new InMemoryDataStore());
            var records = client.GetRecords();

            Console.WriteLine(records);
            Console.ReadLine();
        }
    }
}
