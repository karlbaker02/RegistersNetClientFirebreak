namespace GovukRegistersApiClientNet.Models
{
    public class Item : IItem
    {
        public string Hash { get; set; }
        public dynamic Data { get; set; }

        public Item(string hash, dynamic data)
        {
            Hash = hash;
            Data = data;
        }
    }
}
