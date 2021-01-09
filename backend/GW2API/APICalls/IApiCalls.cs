using BaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GW2API.APICalls
{
    public interface IApiCalls
    {
        public Task<IEnumerable<Listing>> GetAllListings();
    }
}
