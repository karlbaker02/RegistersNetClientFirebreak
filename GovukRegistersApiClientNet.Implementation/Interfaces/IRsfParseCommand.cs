using System;
using System.Collections.Generic;
using System.Text;

namespace GovukRegistersApiClientNet.Implementation.Interfaces
{
    public interface IRsfCommandHandler
    {
        string GetName();

        void Parse(string[] rsfComponents, IDataStore dataStore);
    }
}
