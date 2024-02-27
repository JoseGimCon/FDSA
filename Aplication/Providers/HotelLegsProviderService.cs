using Aplication.Providers.Interfaces;
using AutoMapper;
using Domain.Entities.Hub;
using Domain.HotelLegsSearch;
using Infrastucture.ProviderConectors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aplication.Providers
{
    public class HotelLegsProviderService : IProviderService
    {
        private readonly IHotelLegsConnector _hotelLegsConnection;

        private IMapper _mapper;
        public HotelLegsProviderService(IHotelLegsConnector hotelLegsConnection, IMapper mappeer)
        {
            _hotelLegsConnection = hotelLegsConnection;
            _mapper = mappeer;
        }

        public async Task<HUBSearchResponse> Search(HUBSearchRequest request)
        {
            HotelLegsSearchRequest hotelLegsRequest = _mapper.Map<HotelLegsSearchRequest>(request);

            HotelLegsSearchResponse hotelReponse = await _hotelLegsConnection.Search(hotelLegsRequest);

            var hubSearchResponse = _mapper.Map<HUBSearchResponse>(hotelReponse);

            return hubSearchResponse;
        }
    }
}
