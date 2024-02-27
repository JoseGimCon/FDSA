using Infrastucture.ProviderConectors;
using Infrastucture.ProviderConectors.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastucture.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddInfrasturtureExtension(this IServiceCollection services)
        {
            services.AddScoped<IHotelLegsConnector, HotelLegsConnector>();

        }
    }
}
