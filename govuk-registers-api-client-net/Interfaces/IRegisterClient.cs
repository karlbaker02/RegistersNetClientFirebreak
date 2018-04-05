using GovukRegistersApiClientNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GovukRegistersApiClientNet.Interfaces
{
    public interface IRegisterClient
    {
        IEntry GetEntry(int entryNumber);
        IEnumerable<IEntry> GetEntries();

        IItem GetItem(string itemHash);
        IEnumerable<IItem> GetItems();

        IRecord GetRecord(string key);
        IEnumerable<IRecord> GetRecords();
        IEnumerable<IRecord> GetCurrentRecords();
        IEnumerable<IRecord> GetExpiredRecords();
    }
}
