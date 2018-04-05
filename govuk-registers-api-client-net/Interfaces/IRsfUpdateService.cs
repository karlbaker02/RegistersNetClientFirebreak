using System;
using System.Collections.Generic;
using System.Text;

namespace GovukRegistersApiClientNet.Interfaces
{
    public interface IRsfUpdateService
    {
        void UpdateData(string rsf, IDataStore dataStore);
    }
}
