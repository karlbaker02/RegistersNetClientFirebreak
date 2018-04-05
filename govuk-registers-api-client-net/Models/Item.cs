using Newtonsoft.Json;
using System.Collections.Generic;

namespace GovukRegistersApiClientNet.Models
{
    public class Item
    {
        public readonly string Hash;
        public readonly Dictionary<string, dynamic> Json;

        public Item(string hash, string json)
        {
            Hash = hash;
            Json = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
        }
    }
}
