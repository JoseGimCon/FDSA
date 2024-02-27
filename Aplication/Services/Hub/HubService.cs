using Aplication.Providers.Interfaces;
using Aplication.Services.Hub.Interfaces;
using Aplication.Wrappers;
using Domain.Entities.Hub;
using System.Text.Json;

namespace Aplication.Services.Hub
{
    public class HubService : IHubService
    {
        private readonly IEnumerable<IProviderService> _providers;

        public HubService(IEnumerable<IProviderService> providers)
        {
            _providers = providers;
        }

        public async Task<HUBSearchResponse> Search(HUBSearchRequest request)
        {
            HUBSearchResponse responseHubService = new HUBSearchResponse();
            responseHubService.Rooms = new List<Room>();
            foreach (var provider in _providers)
            {
                HUBSearchResponse responseProvider = await provider.Search(request);
                if(responseProvider != null)
                    responseHubService.Rooms.AddRange(responseProvider.Rooms);
            }
            return responseHubService;
        }
    }
}
