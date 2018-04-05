using GovukRegistersApiClientNet.Enums;
using GovukRegistersApiClientNet.Interfaces;
using GovukRegistersApiClientNet.Models;
using System;
using System.Collections.Generic;
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
        private readonly HttpClient _httpClient;
        private readonly SHA256Managed _sha256;
        private readonly Dictionary<string, Record> _records;

        public RegisterClient(string register, Phase phase, IDataStore dataStore)
        {
            _register = register;
            _phase = phase;
            _dataStore = dataStore;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"https://{register}.{(phase == Phase.ReadyToUse ? "register.gov.uk" : "alpha.openregister.org")}/")
            };
            _sha256 = new SHA256Managed();
            _records = new Dictionary<string, Record>();

            var rsf = DownloadRsf().GetAwaiter().GetResult();
            ParseRsf(rsf);
            Console.WriteLine(rsf);
        }

        public async Task<IEnumerable<Entry>> GetEntries()
        {
            return null;
        }

        public Record GetRecord(string key)
        {
            return _dataStore.GetRecord(EntryType.User, key);
        }

        public IEnumerable<Record> GetRecords()
        {
            return _dataStore.GetRecords(EntryType.User);
        }

        public async Task<string> DownloadRsf()
        {
            return await _httpClient.GetStringAsync("download-rsf");
        }

        public void ParseRsf(string rsf)
        {
            var rsfLines = rsf.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var entryNumbers = new Dictionary<string, int>
            {
                { "user", 1 },
                { "system", 1 }
            };

            foreach (var line in rsfLines)
            {
                var components = line.Split('\t');
                var commandType = components[0];

                if (commandType == "add-item")
                {
                    var json = components[1];
                    var hash = $"sha-256:{ ComputeSha256Hash(json).ToLower() }";

                    _dataStore.AddItem(new Item(hash, json));
                }
                else if (commandType == "append-entry")
                {
                    var entryType = components[1];
                    var key = components[2];
                    var timestamp = DateTime.Parse(components[3]);
                    var itemHash = components[4];
                    var entryNumber = entryNumbers[entryType]++;

                    _dataStore.AppendEntry(new Entry(entryNumber, entryType, key, itemHash, timestamp));
                }
            }
        }

        private string ComputeSha256Hash(string input)
        {
            var sb = new StringBuilder();

            foreach (byte b in _sha256.ComputeHash(Encoding.UTF8.GetBytes(input)))
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

        
    }
}
