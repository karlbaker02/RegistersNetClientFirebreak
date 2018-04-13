using GovukRegistersApiClientNet.Enums;
using GovukRegistersApiClientNet.Implementation.Commands;
using GovukRegistersApiClientNet.Implementation.Interfaces;
using GovukRegistersApiClientNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

            var commandHandlers = new Dictionary<string, IRsfCommandHandler>
            {
                { "add-item", new AddItemCommandHandler(_sha256Service) },
                { "append-entry", new AppendEntryCommandHandler(entryNumbers) },
                { "assert-root-hash", new AssertRootHashCommandHandler() }
            };

            foreach (var line in rsfLines)
            {
                var components = line.Split('\t');
                var commandType = components[0];

                commandHandlers[commandType].Parse(components, dataStore);
            }
        }
    }
}
