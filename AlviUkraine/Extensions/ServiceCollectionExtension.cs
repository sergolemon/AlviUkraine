namespace AlviUkraine.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllersWithViews()
                .AddViewLocalization();
        }
    }
}
