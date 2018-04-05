namespace GovukRegistersApiClientNet.Models
{
    public class Record
    {
        private readonly Item _item;
        private readonly Entry _entry;

        public Record(Item item, Entry entry)
        {
            _item = item;
            _entry = entry;
        }

        public Item GetItem()
        {
            return _item;
        }

        public Entry GetEntry()
        {
            return _entry;
        }
    }
}
