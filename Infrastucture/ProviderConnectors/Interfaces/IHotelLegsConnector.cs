using Domain.HotelLegsSearch;
using System.Threading.Tasks;

namespace Infrastucture.ProviderConectors.Interfaces
{
    public interface IHotelLegsConnector
    {
        Task<HotelLegsSearchResponse> Search(HotelLegsSearchRequest request);
    }
}
