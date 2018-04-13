using GovukRegistersApiClientNet.Implementation.Interfaces;
using GovukRegistersApiClientNet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovukRegistersApiClientNet.Implementation.Commands
{
    public class AddItemCommandHandler : IRsfCommandHandler
    {
        private readonly ISha256Service _sha256Service;

        public AddItemCommandHandler(ISha256Service sha256Service)
        {
            _sha256Service = sha256Service;
        }

        public string GetName()
        {
            return "add-item";
        }

        public void Parse(string[] rsfComponents, IDataStore dataStore)
        {
            var json = rsfComponents[1];
            var hash = $"sha-256:{ _sha256Service.ComputeSha256Hash(json).ToLower() }";

            dataStore.AddItem(new Item(hash, json));
        }
    }
}
