using GovukRegistersApiClientNet.Enums;
using System.Threading.Tasks;

namespace GovukRegistersApiClientNet.Implementation.Interfaces
{
    public interface IRegisterClientFactory
    {
        Task<RegisterClient> CreateRegisterClientAsync(string register, Phase phase, IDataStore dataStore);
    }
}
