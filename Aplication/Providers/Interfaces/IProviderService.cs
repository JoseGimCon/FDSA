using Domain.Entities.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Providers.Interfaces
{
    public interface IProviderService
    {
        Task<HUBSearchResponse> Search(HUBSearchRequest request);
    }
}
