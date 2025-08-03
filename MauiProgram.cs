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

            // Registrar servicios
            builder.Services.AddSingleton<SessionService>();
            builder.Services.AddSingleton<ProductSearchService>();
            builder.Services.AddHttpClient<ProductSearchService>();
            builder.Services.AddSingleton<ProductDetailService>();
            builder.Services.AddHttpClient<ProductDetailService>();
            builder.Services.AddSingleton<CartService>();
            builder.Services.AddSingleton<StoresService>();
            builder.Services.AddSingleton<LocationService>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // Definir rutas para la base de datos de usuarios y carrito
            string UserdbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");
            string CartdbPath = Path.Combine(FileSystem.AppDataDirectory, "cart.db3");
            string StoresdbPath = Path.Combine(FileSystem.AppDataDirectory, "stores.db3");

            // Registrar servicios para UserDatabase y CartService con sus respectivas rutas
            builder.Services.AddSingleton<UserDatabase>(_ => new UserDatabase(UserdbPath));
            builder.Services.AddSingleton<CartService>(_ => new CartService(CartdbPath));
            builder.Services.AddSingleton<StoresService>(_ => new StoresService(CartdbPath));

            // Construir la aplicación
            var app = builder.Build();

            // Inicializar la base de datos y agregar un usuario por defecto si no existe
            InitializeDatabase(app.Services);

            return app;
        }

        // injecta datos a la base de datos
        private static async void InitializeDatabase(IServiceProvider services)
        {
            // Llamada a la clase externa que hace todo el seed
            await DataSeeder.SeedAsync(services);
        }
    }
}
