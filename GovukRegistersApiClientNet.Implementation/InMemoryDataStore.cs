using GovukRegistersApiClientNet.Enums;
using GovukRegistersApiClientNet.Implementation.Interfaces;
using GovukRegistersApiClientNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace GovukRegistersApiClientNet.Implementation
{
    public class InMemoryDataStore : IDataStore
    {
        private readonly Dictionary<string, Item> _items;
        private readonly Dictionary<string, Dictionary<int, Entry>> _entries;
        private readonly Dictionary<string, Dictionary<string, int>> _recordEntryMappings;

        public InMemoryDataStore()
        {
            _items = new Dictionary<string, Item>();
            _entries = new Dictionary<string, Dictionary<int, Entry>>
            {
                { EntryType.User, new Dictionary<int, Entry>() },
                { EntryType.System, new Dictionary<int, Entry>() }
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
            _entries[entry.EntryType].Add(entry.EntryNumber, entry);
            _recordEntryMappings[entry.EntryType][entry.Key] = entry.EntryNumber;
        }

        public Entry GetEntry(string entryType, int entryNumber)
        {
            return _entries[entryType].ContainsKey(entryNumber) ? _entries[entryType][entryNumber] : null;
        }

        public IEnumerable<Entry> GetEntries(string entryType)
        {
            return _entries[entryType].Values;
        }

        public Item GetItem(string itemHash)
        {
            return _items.ContainsKey(itemHash) ? _items[itemHash] : null;
        }

        public IEnumerable<Item> GetItems()
        {
            return _items.Values;
        }

        public int GetLatestEntryNumber(string entryType)
        {
            return _entries[entryType].Any() ? _entries[entryType].Keys.Max() : 0;
        }

        public Record GetRecord(string entryType, string key)
        {
            if (!_recordEntryMappings[entryType].ContainsKey(key))
            {
                return null;
            }

            return GetRecord(entryType, _recordEntryMappings[entryType][key]);
        }

        public Record GetRecord(string entryType, int entryNumber)
        {
            var entry = _entries[entryType][entryNumber];
            return new Record(_items[entry.ItemHash], entry);
        }

        public IEnumerable<Record> GetRecords(string entryType)
        {
            return _recordEntryMappings[entryType].Select(kvp =>
            {
                return GetRecord(entryType, kvp.Value);
            });
        }
    }
}
