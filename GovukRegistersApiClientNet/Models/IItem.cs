using System.Collections.Generic;

namespace GovukRegistersApiClientNet.Models
{
    public interface IItem
    {
        string Hash { get; }
        Dictionary<string, dynamic> Data { get; }
    }
}
