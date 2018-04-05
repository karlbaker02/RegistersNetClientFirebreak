using System;

namespace GovukRegistersApiClientNet.Models
{
    public interface IEntry
    {
        int GetEntryNumber();
        string GetEntryType();
        string GetKey();
        string GetItemHash();
        DateTime GetTimestamp();
    }
}
