using RubleAtlas.Infrastructure.Storage.JSON;
using RubleAtlas.Web.Components;

namespace RubleAtlas.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string dataFilepath = @"C:\Users\nahmaida\source\repos\RubleAtlas\RubleAtlas.Infrastructure\Storage\JSON\data.json";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton(_ => new JSONStorage(dataFilepath));

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
                
            // Add localization support
            builder.Services.AddLocalization();

            // Enable detailed errors
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddServerSideBlazor()
                    .AddCircuitOptions(o => o.DetailedErrors = true);
            }
            else
            {
                builder.Services.AddServerSideBlazor();
            }

            var app = builder.Build();

            // Configure localization
            var supportedCultures = new[] { "en", "ru" };
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();


            app.Run();
        }
    }
}
