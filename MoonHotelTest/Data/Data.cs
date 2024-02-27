using Aplication.Wrappers;
using Domain.Entities.Hub;
using Domain.HotelLegsSearch;
using System.Text.Json;

namespace MoonHotelTests.Data
{
    public static class FixtureData
    {
        public static HUBSearchRequest GetHUBSearchRequest = new HUBSearchRequest()
        {
            hotelId = 1,
            checkIn = new DateTime(2028, 10, 20),
            checkOut = new DateTime(2028, 10, 25),
            numberOfGuests = 3,
            numberOfRooms = 1,
            currency = "EUR"
        };
        public static HUBSearchResponse GetHUBSearchResponse()
        {
            string json = $"{{\"Rooms\":[{{\"RoomId\":1,\"Rates\":[{{\"MealPlanId\":1,\"IsCancellable\":false,\"Price\":123.48}},{{\"MealPlanId\":1,\"IsCancellable\":true,\"Price\":150}}]}},{{\"RoomId\":2,\"Rates\":[{{\"MealPlanId\":1,\"IsCancellable\":false,\"Price\":148.25}},{{\"MealPlanId\":2,\"IsCancellable\":false,\"Price\":165.38}}]}}]}}";
            return JsonSerializer.Deserialize<HUBSearchResponse>(json);
        }
        public static Response<HUBSearchResponse> GetMoonHotelResponse()
        {
            return new Response<HUBSearchResponse>(GetHUBSearchResponse());
        }
        public static HotelLegsSearchRequest GetHotelLegsSearchRequest = new HotelLegsSearchRequest()
        {
            hotel = 1,
            checkInDate = "2028-10-25",
            numberOfNights = 5,
            guests = 3,
            rooms = 2,
            currency = "EUR"
        };
        public static HotelLegsSearchResponse GetHotelLegsSearchResponse() {
            string json = $"{{\"results\":[{{\"room\":1,\"meal\":1,\"canCancel\":false,\"price\":123.48}},{{\"room\":1,\"meal\":1,\"canCancel\":true,\"price\":150}},{{\"room\":2,\"meal\":1,\"canCancel\":false,\"price\":148.25}},{{\"room\":2,\"meal\":2,\"canCancel\":false,\"price\":165.38}}]}}";
            return JsonSerializer.Deserialize<HotelLegsSearchResponse>(json);
        }
    }
}
