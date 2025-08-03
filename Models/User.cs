using SQLite;
using System.ComponentModel.DataAnnotations;

namespace GlobalApp.Models;

public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Unique, NotNull]
    public string Username { get; set; }

    [NotNull]
    public string Password { get; set; }

    public string ProfileImage { get; set; }
}
