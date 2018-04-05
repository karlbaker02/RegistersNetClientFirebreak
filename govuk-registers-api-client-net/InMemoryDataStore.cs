using GovukRegistersApiClientNet.Enums;
using GovukRegistersApiClientNet.Interfaces;
using GovukRegistersApiClientNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GovukRegistersApiClientNet
{
    public class InMemoryDataStore : IDataStore
    {
        private readonly Dictionary<string, Item> _items;
        private readonly Dictionary<string, List<Entry>> _entries;
        private readonly Dictionary<string, Dictionary<string, int>> _recordEntryMappings;

        public InMemoryDataStore()
        {
            _items = new Dictionary<string, Item>();
            _entries = new Dictionary<string, List<Entry>>
            {
                { EntryType.User, new List<Entry>() },
                { EntryType.System, new List<Entry>() }
            };
            _recordEntryMappings = new Dictionary<string, Dictionary<string, int>>
            {
                { EntryType.User, new Dictionary<string, int>() },
                { EntryType.System, new Dictionary<string, int>() }
            };
        }

        public void AddItem(Item item)
        {
            _items.Add(item.Hash, item);
        }

        public void AppendEntry(Entry entry)
        {
            _entries[entry.EntryType].Add(entry);
            _recordEntryMappings[entry.EntryType][entry.Key] = entry.EntryNumber;
        }

        public IEnumerable<Entry> GetEntries(string entryType)
        {
            return _entries[entryType];
        }

        public Record GetRecord(string entryType, string key)
        {
            var entry = _entries[entryType][_recordEntryMappings[entryType][key] - 1];
            return new Record(_items[entry.ItemHash], entry);
        }

        public IEnumerable<Record> GetRecords(string entryType)
        {
            var records = _recordEntryMappings[entryType].Select(kvp =>
            {
                var entry = _entries[entryType][kvp.Value - 1];
                return new Record(_items[entry.ItemHash], entry);
            });
            return records;
        }
    }
}
