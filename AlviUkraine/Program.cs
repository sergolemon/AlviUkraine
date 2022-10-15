using AlviUkraine.Extensions;
using Microsoft.AspNetCore.Localization;
using Serilog;
using Serilog.Events;
using System.Globalization;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().WriteTo.File(
        path: builder.Configuration.GetValue<string>("Serilog:Path"),
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel: LogEventLevel.Information
    ));

    builder.Services.AddServices();

    var app = builder.Build();

    app.UseLocalization();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/error.html");
    }

    app.UseStatusCodePages();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseEndpoints(cfg =>
    {
        cfg.MapControllerRoute("default", "{controller=home}/{action=index}");
    });

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start.");
}
finally
{
    Log.Information("Application is finishing.");
    Log.CloseAndFlush();
}