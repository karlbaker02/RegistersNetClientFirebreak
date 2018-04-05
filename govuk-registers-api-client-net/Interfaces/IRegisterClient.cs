using GovukRegistersApiClientNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GovukRegistersApiClientNet.Interfaces
{
    public interface IRegisterClient
    {
        Entry GetEntry(int entryNumber);
        IEnumerable<Entry> GetEntries();

        Item GetItem(string itemHash);
        IEnumerable<Item> GetItems();

        Record GetRecord(string key);
        IEnumerable<Record> GetRecords();
        IEnumerable<Record> GetCurrentRecords();
        IEnumerable<Record> GetExpiredRecords();
    }
}
