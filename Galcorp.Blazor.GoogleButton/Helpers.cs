using Galcorp.Blazor.GoogleButton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Helpers
    {
        public static IServiceCollection AddGalcorpGoogleButton(this IServiceCollection services, GButtonConfig options)
        {
            services.AddSingleton<GButtonConfig>(options);
            return services.AddScoped<ProfileService>();
        }
    }
}
