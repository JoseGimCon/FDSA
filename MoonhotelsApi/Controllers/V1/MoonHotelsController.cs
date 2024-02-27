using Aplication.Services.Hub.Interfaces;
using Aplication.Wrappers;
using Asp.Versioning;
using Domain.Entities.Hub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MoonhotelsApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class MoonHotelsController : ControllerBase
    {
        private readonly IHubService _hubService;

        public MoonHotelsController(IHubService hubService)
        {
            _hubService = hubService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Search(HUBSearchRequest HubSearchRequest)
        {
            try
            {
                var responHubServices = await _hubService.Search(HubSearchRequest);

                var responseModel = new Response<HUBSearchResponse>(responHubServices);

                return Ok(responseModel);
            }
            catch (Exception ex)
            {

                var responseModel = new Response<string>() { Succeeded = false, Message = ex.Message };

                return new BadRequestObjectResult(responseModel);
            }
        }
    }
}
