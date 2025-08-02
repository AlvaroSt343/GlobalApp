using GlobalApp.Services;
using Microsoft.Extensions.Logging;

namespace GlobalApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });


            builder.Services.AddSingleton<SessionService>();
            builder.Services.AddSingleton<ProductSearchService>();
            builder.Services.AddHttpClient<ProductSearchService>();
            builder.Services.AddSingleton<ProductDetailService>();
            builder.Services.AddHttpClient<ProductDetailService>();




            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");
            builder.Services.AddSingleton<UserDatabase>(_ => new UserDatabase(dbPath));

            var app = builder.Build();

            var db = app.Services.GetService<UserDatabase>();
            _ = db?.SaveUserAsync(new Models.User { Username = "admin", Password = "1234" });
            _ = db?.SaveUserAsync(new Models.User { Username = "user1", Password = "user1" });
            _ = db?.SaveUserAsync(new Models.User { Username = "user2", Password = "user2" });


            return app;
        }
    }
}
