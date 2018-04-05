using System;

namespace GovukRegistersApiClientNet.Models
{
    public class Entry : IEntry
    {
        private readonly int _entryNumber;
        private readonly string _entryType;
        private readonly string _key;
        private readonly string _itemHash;
        private readonly DateTime _timestamp;

        public Entry(int entryNumber, string entryType, string key, string itemHash, DateTime timestamp)
        {
            _entryNumber = entryNumber;
            _entryType = entryType;
            _key = key;
            _itemHash = itemHash;
            _timestamp = timestamp;
        }

        public int GetEntryNumber() => _entryNumber;
        public string GetEntryType() => _entryType;
        public string GetKey() => _key;
        public string GetItemHash() => _itemHash;
        public DateTime GetTimestamp() => _timestamp;
    }
}
