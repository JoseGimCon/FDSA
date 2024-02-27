using Aplication.Wrappers;
using Domain.Entities.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Hub.Interfaces
{
    public interface IHubService
    {
        Task<HUBSearchResponse> Search(HUBSearchRequest request);
    }
}
