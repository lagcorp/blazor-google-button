// ReSharper disable once CheckNamespace
using Galcorp.Blazor.GoogleButton;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Helpers
    {
        public static IServiceCollection AddGalcorpGoogleButton(this IServiceCollection services, GButtonConfig options)
        {
            services.AddSingleton<GButtonConfig>(options);

            return services.AddScoped<GButtonService>();
        }
    }
}
