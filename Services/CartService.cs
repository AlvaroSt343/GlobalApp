using GlobalApp.Models;
using SQLite;

namespace GlobalApp.Services
{
    public class CartService
    {
        private readonly SQLiteAsyncConnection _db;

        public CartService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<CartItem>().Wait();
        }

        public Task<int> SaveToCartAsync(CartItem item)
        {
            return _db.InsertAsync(item);
        }

        public Task<List<CartItem>> GetCartItemsAsync()
        {
            return _db.Table<CartItem>().ToListAsync();
        }
        public async Task<int> GetCartItemCountAsync (string username)
        {
            try
            {
                return await _db.Table<CartItem>()
                                .Where(item => item.Username == username)
                                .CountAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al contar items en el carrito: {e.Message}");
                return 0;
            }
        }


    }
}
