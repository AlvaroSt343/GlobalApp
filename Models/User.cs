using SQLite;

namespace GlobalApp.Models;

public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Unique, NotNull]
    public string Username { get; set; }

    [NotNull]
    public string Password { get; set; }
}
