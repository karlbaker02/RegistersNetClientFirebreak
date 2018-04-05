using GovukRegistersApiClientNet.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GovukRegistersApiClientNet.Interfaces
{
    public interface IRsfDownloadService
    {
        Task<string> Download(string register, Phase phase, int startEntryNumber);
    }
}
