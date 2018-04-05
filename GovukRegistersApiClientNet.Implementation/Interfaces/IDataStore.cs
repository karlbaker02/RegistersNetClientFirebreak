using GovukRegistersApiClientNet.Models;
using System.Collections.Generic;

namespace GovukRegistersApiClientNet.Implementation.Interfaces
{
    public interface IDataStore
    {
        void AddItem(Item item);
        void AppendEntry(Entry entry);

        Entry GetEntry(string entryType, int entryNumber);
        IEnumerable<Entry> GetEntries(string entryType);
        int GetLatestEntryNumber(string entryType);

        Item GetItem(string itemHash);
        IEnumerable<Item> GetItems();

        Record GetRecord(string entryType, string key);
        IEnumerable<Record> GetRecords(string entypeType);
        
    }
}
