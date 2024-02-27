using Aplication.Providers.Interfaces;
using Domain.Entities.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Providers
{
    public class SpeediaProviderService : IProviderService
    {
        public async Task<HUBSearchResponse> Search(HUBSearchRequest request)
        {
            HUBSearchResponse response = null;
            return response;
        }
    }
}
