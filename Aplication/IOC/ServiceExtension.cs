using Aplication.DTOs.Hub.Validators;
using Aplication.Mappings;
using Aplication.Providers;
using Aplication.Providers.Interfaces;
using Aplication.Services.Hub;
using Aplication.Services.Hub.Interfaces;
using Aplication.Wrappers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Aplication.IOC
{
    public static class ServiceExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {


            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<HUBSearchRequestValidator>();
            services.AddScoped<IProviderService, HotelLegsProviderService>();
            services.AddScoped<IProviderService, SpeediaProviderService>();
            services.AddScoped<IProviderService, TravelDoorXProviderService>();

            services.AddScoped<IHubService, HubService>();
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var messages = context.ModelState.Values
                        .Where(x => x.ValidationState == ModelValidationState.Invalid)
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToList();
                    var responseModel = new Response<string>() { Succeeded = false, Message = "One or more validation errors have occurred" };

                    responseModel.Errors = messages;
                    return new BadRequestObjectResult(responseModel);
                         
                };
            });






        }
    }
}
