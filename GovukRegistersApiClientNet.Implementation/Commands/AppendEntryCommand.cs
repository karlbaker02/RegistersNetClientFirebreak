using GovukRegistersApiClientNet.Implementation.Interfaces;
using GovukRegistersApiClientNet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovukRegistersApiClientNet.Implementation.Commands
{
    public class AppendEntryCommandHandler : IRsfCommandHandler
    {
        private readonly Dictionary<string, int> _entryNumbers;

        public AppendEntryCommandHandler(Dictionary<string, int> entryNumbers)
        {
            _entryNumbers = entryNumbers;
        }

        public string GetName()
        {
            return "append-entry";
        }

        public void Parse(string[] rsfComponents, IDataStore dataStore)
        {
            var entryType = rsfComponents[1];
            var key = rsfComponents[2];
            var timestamp = DateTime.Parse(rsfComponents[3]);
            var itemHash = rsfComponents[4];
            var entryNumber = ++_entryNumbers[entryType];

            dataStore.AppendEntry(new Entry(entryNumber, entryType, key, itemHash, timestamp));
        }
    }
}
