namespace GovukRegistersApiClientNet.Models
{
    public class Record : IRecord
    {
        public IItem Item { get; set; }
        public IEntry Entry { get; set; }

        public Record(IItem item, IEntry entry)
        {
            Item = item;
            Entry = entry;
        }
    }
}
