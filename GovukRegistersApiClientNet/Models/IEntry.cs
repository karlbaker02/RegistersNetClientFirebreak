using System;

namespace GovukRegistersApiClientNet.Models
{
    public interface IEntry
    {
        int EntryNumber { get; }
        string EntryType { get; }
        string Key { get; }
        string ItemHash { get; }
        DateTime Timestamp { get; }
    }
}
