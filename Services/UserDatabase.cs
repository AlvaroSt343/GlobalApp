using GlobalApp.Models;
using SQLite;

namespace GlobalApp.Services;

public class UserDatabase
{
    private readonly SQLiteAsyncConnection _db;

    public UserDatabase(string dbPath)
    {
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<User>().Wait();
    }

    public Task<User?> GetUserAsync(string username, string password)
    {
        return _db.Table<User>()
                  .Where(u => u.Username == username && u.Password == password)
                  .FirstOrDefaultAsync();
    }

    public Task<int> SaveUserAsync(User user)
    {
        return _db.InsertAsync(user);
    }
}
