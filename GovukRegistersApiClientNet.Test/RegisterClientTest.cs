using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GovukRegistersApiClientNet.Models;
using System.Linq;
using GovukRegistersApiClientNet.Enums;
using System.Threading.Tasks;
using System;
using GovukRegistersApiClientNet.Services;

namespace GovukRegistersApiClientNet.Test
{
    [TestClass]
    public class RegisterClientTest
    {
        private RegisterClient Client;

        public RegisterClientTest()
        {
            Client = new RegisterClient("country", Phase.ReadyToUse, new InMemoryDataStore(), new RsfDownloadService(), new RsfUpdateService(new Sha256Service()));
        }

        [TestMethod]
        public void GetEntries_ShouldReturnEntries()
        {
            var expectedEntries = new List<Entry>
            {
                new Entry(1, EntryType.User, "GB", "sha-256:6b18693874513ba13da54d61aafa7cad0c8f5573f3431d6f1c04b07ddb27d6bb", DateTime.Now)
            };

            var actualEntries = Client.GetEntries();

            CollectionAssert.AreEqual(expectedEntries, actualEntries.ToList());
        }
    }
}
