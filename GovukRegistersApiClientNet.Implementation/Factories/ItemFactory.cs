using GovukRegistersApiClientNet.Implementation.Helpers;
using GovukRegistersApiClientNet.Implementation.Interfaces;
using GovukRegistersApiClientNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovukRegistersApiClientNet.Implementation.Factories
{
    public class ItemFactory : IItemFactory
    {
        private readonly ISha256Service _sha256Service;
        private readonly JsonConverter _jsonConverter;

        public ItemFactory(ISha256Service sha256Service, JsonConverter jsonConverter)
        {
            _sha256Service = sha256Service;
            _jsonConverter = jsonConverter;
        }

        public Item CreateItem(string json)
        {
            var hash = $"sha-256:{ _sha256Service.ComputeSha256Hash(json).ToLower() }";
            dynamic data = JsonConvert.DeserializeObject<dynamic>(json, _jsonConverter);

            return new Item(hash, data);
        }
    }
}
