using Newtonsoft.Json;
using System.Collections.Generic;

namespace GovukRegistersApiClientNet.Models
{
    public class Item : IItem
    {
        private readonly string _hash;
        private readonly Dictionary<string, dynamic> _json;

        public Item(string hash, string json)
        {
            _hash = hash;
            _json = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
        }

        public string GetItemHash() => _hash;
        public Dictionary<string, dynamic> GetData() => _json;
    }
}
