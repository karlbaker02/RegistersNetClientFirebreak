using System;
using System.Collections.Generic;
using System.Text;

namespace GovukRegistersApiClientNet.Implementation.Interfaces
{
    public interface ISha256Service
    {
        string ComputeSha256Hash(string input);
    }
}
