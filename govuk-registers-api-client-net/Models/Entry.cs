using GovukRegistersApiClientNet.Enums;
using System;
using System.Security.Cryptography;

namespace GovukRegistersApiClientNet.Models
{
    public class Entry
    {
        public readonly int EntryNumber;
        public readonly string EntryType;
        public readonly string Key;
        public readonly string ItemHash;
        public readonly DateTime Timestamp;

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
