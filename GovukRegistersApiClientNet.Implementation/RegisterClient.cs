using GovukRegistersApiClientNet.Enums;
using GovukRegistersApiClientNet.Implementation.Interfaces;
using GovukRegistersApiClientNet.Interfaces;
using GovukRegistersApiClientNet.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovukRegistersApiClientNet.Implementation
{
    public class RegisterClient : IRegisterClient
    {
        private readonly string _register;
        private readonly Phase _phase;
        private readonly IDataStore _dataStore;
        private readonly IRsfDownloadService _rsfDownloadService;
        private readonly IRsfUpdateService _rsfUpdateService;

        public RegisterClient(string register, 
            Phase phase, 
            IDataStore dataStore, 
            IRsfDownloadService rsfDownloadService, 
            IRsfUpdateService rsfUpdateService)
        {
            _register = register;
            _phase = phase;
            _dataStore = dataStore;
            _rsfDownloadService = rsfDownloadService;
            _rsfUpdateService = rsfUpdateService;
        }

        public IEntry GetEntry(int entryNumber)
        {
            return _dataStore.GetEntry(EntryType.User, entryNumber);
        }

        public IEnumerable<IEntry> GetEntries()
        {
            return _dataStore.GetEntries(EntryType.User);
        }

        public IItem GetItem(string itemHash)
        {
            return _dataStore.GetItem(itemHash);
        }

        public IEnumerable<IItem> GetItems()
        {
            return _dataStore.GetItems();
        }

        public IRecord GetRecord(string key)
        {
            return _dataStore.GetRecord(EntryType.User, key);
        }

        public IEnumerable<IRecord> GetRecords()
        {
            return _dataStore.GetRecords(EntryType.User);
        }

        public IEnumerable<IRecord> GetCurrentRecords()
        {
            return GetRecords().ToList()
                .Where(r => !r.GetItem().GetData().ContainsKey("end-date"));
        }

        public IEnumerable<IRecord> GetExpiredRecords()
        {
            return GetRecords().ToList()
                .Where(r => r.GetItem().GetData().ContainsKey("end-date"));
        }

        public async Task RefreshData()
        {
            var latestEntryNumber = _dataStore.GetLatestEntryNumber(EntryType.User);
            var updateRsf = await _rsfDownloadService.Download(_register, _phase, latestEntryNumber);

            _rsfUpdateService.UpdateData(updateRsf, _dataStore);
        }
    }
}
