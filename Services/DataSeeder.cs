using GlobalApp.Models;

namespace GlobalApp.Services
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            // 1) Sembrar usuario por defecto
            var userDb = services.GetService<UserDatabase>();
            if (userDb != null)
            {
                var existingUser = await userDb.GetUserAsync("admin", "1234");
                if (existingUser == null)
                {
                    await userDb.SaveUserAsync(new User { Username = "admin", Password = "1234" });
                }
            }

            // 2) Sembrar tiendas por defecto
            var storeSvc = services.GetService<StoresService>();
            if (storeSvc != null)
            {
                var existingStores = await storeSvc.GetAllAsync();
                if (existingStores == null || existingStores.Count == 0)
                {
                    var defaults = new List<Stores>
                    {
                        new Stores {
                            Name = "Global Technical Services",
                            Location = "Av. Siempre Viva 742, Springfield",
                            Latitude  = 19.432608,
                            Longitude = -99.133209
                        },
                        new Stores {
                            Name = "Tech Solutions Hub",
                            Location = "Calle 8 #123, Ciudad Gótica",
                            Latitude  = 28.704060,
                            Longitude = 77.102493
                        },
                        new Stores {
                            Name = "Innovatec",
                            Location = "Paseo de la Reforma 1000, CDMX",
                            Latitude  = 19.427025,
                            Longitude = -99.167665
                        }
                    };

                    foreach (var s in defaults)
                    {
                        await storeSvc.SaveStoreAsync(s);
                    }
                }
            }
        }
    }
}
