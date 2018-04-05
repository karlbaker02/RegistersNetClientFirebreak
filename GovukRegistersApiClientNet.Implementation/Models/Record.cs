namespace GovukRegistersApiClientNet.Models
{
    public class Record : IRecord
    {
        private readonly IItem _item;
        private readonly IEntry _entry;

        public Record(IItem item, IEntry entry)
        {
            _item = item;
            _entry = entry;
        }

        public IItem GetItem()
        {
            return _item;
        }

        public IEntry GetEntry()
        {
            return _entry;
        }
    }
}
