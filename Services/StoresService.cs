using GlobalApp.Models;
using SQLite;
namespace GlobalApp.Services
{
    public class StoresService
    {
        private readonly SQLiteAsyncConnection _db;
        public StoresService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Stores>().Wait();
        }
        public Task<List<Stores>> GetAllAsync() => _db.Table<Stores>().ToListAsync();


        public Task<int> SaveStoreAsync(Stores store) => _db.InsertAsync(store);

    }
}
