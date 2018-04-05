using GovukRegistersApiClientNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GovukRegistersApiClientNet.Interfaces
{
    public interface IRegisterClient
    {
        Task<IEnumerable<Entry>> GetEntries();

        Record GetRecord(string key);

        IEnumerable<Record> GetRecords();
    }
}
