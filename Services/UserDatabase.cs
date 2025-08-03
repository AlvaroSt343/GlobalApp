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

    public Task<List<User>> GetAllUsersAsync()
    => _db.Table<User>().ToListAsync();

    public Task<User?> GetUserAsync(string username, string password)
    {
        return _db.Table<User>()
                  .Where(u => u.Username == username && u.Password == password)
                  .FirstOrDefaultAsync();
    }

    public Task<User?> GetUserByUsernameAsync(string username)
    {
        return _db.Table<User>()
                  .Where(u => u.Username == username)
                  .FirstOrDefaultAsync();
    }

    public Task<int> SaveUserAsync(User user)
    {
        return _db.InsertAsync(user);
    }

    public Task<int> UpdateUserAsync(User user)
            => _db.UpdateAsync(user);

}
