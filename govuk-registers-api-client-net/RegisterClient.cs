using GovukRegistersApiClientNet.Enums;
using GovukRegistersApiClientNet.Interfaces;
using GovukRegistersApiClientNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GovukRegistersApiClientNet
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

        private async Task<RegisterClient> InitializeAsync()
        {
            await RefreshData();
            return this;
        }

        public static Task<RegisterClient> CreateAsync(string register, Phase phase, IDataStore dataStore, IRsfDownloadService rsfDownloadService, IRsfUpdateService rsfUpdateService)
        {
            var instance = new RegisterClient(register, phase, dataStore, rsfDownloadService, rsfUpdateService);

            return instance.InitializeAsync();
        }

        public Entry GetEntry(int entryNumber)
        {
            return _dataStore.GetEntry(EntryType.User, entryNumber);
        }

        public IEnumerable<Entry> GetEntries()
        {
            return _dataStore.GetEntries(EntryType.User);
        }

        public Item GetItem(string itemHash)
        {
            return _dataStore.GetItem(itemHash);
        }

        public IEnumerable<Item> GetItems()
        {
            return _dataStore.GetItems();
        }

        public Record GetRecord(string key)
        {
            return _dataStore.GetRecord(EntryType.User, key);
        }

        public IEnumerable<Record> GetRecords()
        {
            return _dataStore.GetRecords(EntryType.User);
        }

        public IEnumerable<Record> GetCurrentRecords()
        {
            return GetRecords().ToList()
                .Where(r => !r.GetItem().Json.ContainsKey("end-date"));
        }

        public IEnumerable<Record> GetExpiredRecords()
        {
            return GetRecords().ToList()
                .Where(r => r.GetItem().Json.ContainsKey("end-date"));
        }

        public async Task RefreshData()
        {
            var latestEntryNumber = _dataStore.GetLatestEntryNumber(EntryType.User);
            var updateRsf = await _rsfDownloadService.Download(_register, _phase, latestEntryNumber);

            _rsfUpdateService.UpdateData(updateRsf, _dataStore);
        }
    }
}
