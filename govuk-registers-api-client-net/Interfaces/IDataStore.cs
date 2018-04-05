using GovukRegistersApiClientNet.Enums;
using GovukRegistersApiClientNet.Models;
using System.Collections;
using System.Collections.Generic;

namespace GovukRegistersApiClientNet.Interfaces
{
    public interface IDataStore
    {
        void AddItem(Item item);

        void AppendEntry(Entry entry);

        IEnumerable<Entry> GetEntries(string entryType);

        Record GetRecord(string entryType, string key);

        IEnumerable<Record> GetRecords(string entypeType);
    }
}
