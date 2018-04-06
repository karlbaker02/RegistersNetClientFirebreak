using Newtonsoft.Json;
using System.Collections.Generic;

namespace GovukRegistersApiClientNet.Models
{
    public class Item : IItem
    {
        public string Hash { get; set; }
        public Dictionary<string, dynamic> Data { get; set; }

        public Item(string hash, string json)
        {
            Hash = hash;
            Data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
        }
    }
}
