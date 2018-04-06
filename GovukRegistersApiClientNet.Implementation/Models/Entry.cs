using System;

namespace GovukRegistersApiClientNet.Models
{
    public class Entry : IEntry
    {
        public int EntryNumber { get; set; }
        public string EntryType { get; set; }
        public string Key { get; set; }
        public string ItemHash { get; set; }
        public DateTime Timestamp { get; set; }

        public Entry(int entryNumber, string entryType, string key, string itemHash, DateTime timestamp)
        {
            EntryNumber = entryNumber;
            EntryType = entryType;
            Key = key;
            ItemHash = itemHash;
            Timestamp = timestamp;
        }
    }
}
