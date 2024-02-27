using Aplication.Mappings;
using Aplication.Providers;
using Aplication.Providers.Interfaces;
using AutoMapper;
using Domain.Entities.Hub;
using Domain.HotelLegsSearch;
using Infrastucture.ProviderConectors.Interfaces;
using MoonHotelTests.Data;
using Moq;

namespace MoonHotelTests
{
    public class HotelLegsProviderServiceUnitTests
    {
        private readonly Mock<IHotelLegsConnector> _mockHotelLegsConnector;
        private Mock<IMapper> _mockMapper;

        public HotelLegsProviderServiceUnitTests()
        {
            _mockHotelLegsConnector = new Mock<IHotelLegsConnector>();

            var profile = new AutoMapperProfile();
            _mockMapper = new Mock<IMapper>();
            _mockMapper.Setup(m => m.ConfigurationProvider).Returns(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(profile);
            }));
        }

        [Fact]
        public async Task HotelLegsProviderService_Search_ReturnsHUBSearchResponse_test()
        {
            // Arrange
            var hotelLegsResponse = FixtureData.GetHotelLegsSearchResponse(); 
            var hubSearchResponse = FixtureData.GetHUBSearchResponse();


            _mockHotelLegsConnector.Setup(c => c.Search(FixtureData.GetHotelLegsSearchRequest))
                                  .ReturnsAsync(hotelLegsResponse); 

            _mockMapper.Setup(m => m.Map<HUBSearchResponse>(It.IsAny<HotelLegsSearchResponse>()))
                      .Returns(hubSearchResponse); 

            var hotelLegsProviderService = new HotelLegsProviderService(_mockHotelLegsConnector.Object, _mockMapper.Object);
           
            // Act
            var result = await hotelLegsProviderService.Search(FixtureData.GetHUBSearchRequest);

            // Assert
            Assert.Equal(hubSearchResponse, result);
           
        }
    }
}