using System.Collections.Generic;

namespace GovukRegistersApiClientNet.Models
{
    public interface IItem
    {
        string GetItemHash();
        Dictionary<string, dynamic> GetData();
    }
}
