using System.Collections.Generic;

namespace GovukRegistersApiClientNet.Models
{
    public interface IItem
    {
        string Hash { get; }
        dynamic Data { get; }
    }
}
