using SQLite;
namespace GlobalApp.Models
{
    public class Stores
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        [NotNull] public string Name { get; set; }
        [NotNull] public string Location { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
