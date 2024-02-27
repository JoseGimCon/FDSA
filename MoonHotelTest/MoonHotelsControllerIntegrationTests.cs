using Aplication.Mappings;
using Aplication.Providers;
using Aplication.Providers.Interfaces;
using Aplication.Services.Hub.Interfaces;
using Aplication.Wrappers;
using AutoMapper;
using Domain.Entities.Hub;
using Domain.HotelLegsSearch;
using Infrastucture.ProviderConectors.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MoonhotelsApi.Controllers.V1;
using MoonHotelTests.Data;
using Moq;

namespace MoonHotelTests
{
    public class HotelLegsProviderServiceIntegrationTests
    {
        private readonly MoonHotelsController _controller;
        private readonly Mock<IHubService> _mockHubService;

        public HotelLegsProviderServiceIntegrationTests()
        {
            _mockHubService = new Mock<IHubService>();
            _controller = new MoonHotelsController(_mockHubService.Object);
        }

        [Fact]
        public async Task Search_ReturnsOkResult_WithValidRequest()
        {
            // Arrange
            var validRequest = FixtureData.GetHUBSearchRequest;
            var validResponse = FixtureData.GetHUBSearchResponse();
            _mockHubService.Setup(x => x.Search(validRequest)).ReturnsAsync(validResponse);

            // Act
            var result = await _controller.Search(validRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var responseModel = Assert.IsAssignableFrom<Response<HUBSearchResponse>>(okResult.Value);
            Assert.True(responseModel.Succeeded);
            Assert.Equal(validResponse, responseModel.Data);
        }

        [Fact]
        public async Task Search_ReturnsBadRequest_WhenServiceThrowsException()
        {
            // Arrange
            var invalidRequest = new HUBSearchRequest();
            var errorMessage = "Error message"; 
            _mockHubService.Setup(x => x.Search(invalidRequest)).ThrowsAsync(new Exception(errorMessage));

            // Act
            var result = await _controller.Search(invalidRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var responseModel = Assert.IsAssignableFrom<Response<string>>(badRequestResult.Value);
            Assert.False(responseModel.Succeeded);
        }
    }
}