using GovukRegistersApiClientNet.Implementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovukRegistersApiClientNet.Implementation.Commands
{
    public class AssertRootHashCommandHandler : IRsfCommandHandler
    {
        public string GetName()
        {
            return "assert-root-hash";
        }

        public void Parse(string[] rsfComponents, IDataStore dataStore)
        {
            // To be implemented
        }
    }
}
