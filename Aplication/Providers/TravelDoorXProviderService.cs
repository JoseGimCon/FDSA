using Aplication.Providers.Interfaces;
using Aplication.Wrappers;
using Domain.Entities.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Providers
{
    public class TravelDoorXProviderService : IProviderService
    {
        public async Task<HUBSearchResponse> Search(HUBSearchRequest request)
        {
            HUBSearchResponse response = null;
            return response;
        }
    }
}
