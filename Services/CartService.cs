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
    }
}
