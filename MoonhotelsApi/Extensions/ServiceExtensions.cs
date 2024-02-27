using Asp.Versioning;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace moonhotelsapi.extensions
{
    public static class ServiceExtensions
    {
        public static void AddapiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);

                config.AssumeDefaultVersionWhenUnspecified = true;

                config.ReportApiVersions = true;
            });

        }
    }
}
