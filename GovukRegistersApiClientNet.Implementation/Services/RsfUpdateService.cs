using GovukRegistersApiClientNet.Enums;
using GovukRegistersApiClientNet.Implementation.Interfaces;
using GovukRegistersApiClientNet.Models;
using System;
using System.Collections.Generic;

namespace GovukRegistersApiClientNet.Implementation.Services
{
    public class RsfUpdateService : IRsfUpdateService
    {
        private readonly ISha256Service _sha256Service;

        public RsfUpdateService(ISha256Service sha256Service)
        {
            _sha256Service = sha256Service;
        }

        public void UpdateData(string rsf, IDataStore dataStore)
        {
            var rsfLines = rsf.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var entryNumbers = new Dictionary<string, int>
            {
                { "user", dataStore.GetLatestEntryNumber(EntryType.User) },
                { "system", dataStore.GetLatestEntryNumber(EntryType.System) }
            };

            foreach (var line in rsfLines)
            {
                var components = line.Split('\t');
                var commandType = components[0];

                if (commandType == "add-item")
                {
                    var json = components[1];
                    var hash = $"sha-256:{ _sha256Service.ComputeSha256Hash(json).ToLower() }";

                    dataStore.AddItem(new Item(hash, json));
                }
                else if (commandType == "append-entry")
                {
                    var entryType = components[1];
                    var key = components[2];
                    var timestamp = DateTime.Parse(components[3]);
                    var itemHash = components[4];
                    var entryNumber = entryNumbers[entryType]++;

                    dataStore.AppendEntry(new Entry(entryNumber, entryType, key, itemHash, timestamp));
                }
            }
        }
    }
}
