using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace AlviUkraine.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseLocalization(this IApplicationBuilder app)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("uk")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("uk"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
        }
    }
}
