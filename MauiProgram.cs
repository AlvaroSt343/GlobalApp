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

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // Definir rutas para la base de datos de usuarios y carrito
            string UserdbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");
            string CartdbPath = Path.Combine(FileSystem.AppDataDirectory, "cart.db3");

            // Registrar servicios para UserDatabase y CartService con sus respectivas rutas
            builder.Services.AddSingleton<UserDatabase>(_ => new UserDatabase(UserdbPath));
            builder.Services.AddSingleton<CartService>(_ => new CartService(CartdbPath));

            // Construir la aplicación
            var app = builder.Build();

            // Inicializar la base de datos y agregar un usuario por defecto si no existe
            InitializeDatabase(app.Services);

            return app;
        }

        // Método para inicializar la base de datos y agregar un usuario por defecto
        private static async void InitializeDatabase(IServiceProvider services)
        {
            var db = services.GetService<UserDatabase>();
            if (db != null)
            {
                // Verificar si ya existe el usuario 'admin' antes de agregarlo
                var existingUser = await db.GetUserAsync("admin", "1234");
                if (existingUser == null)
                {
                    // Agregar un usuario por defecto si no existe
                    await db.SaveUserAsync(new Models.User { Username = "admin", Password = "1234" });
                }
            }
        }
    }
}
