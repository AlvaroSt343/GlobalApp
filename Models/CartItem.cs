using SQLite;

namespace GlobalApp.Models
{
    public class CartItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Asin { get; set; }

        [NotNull]
        public string Title { get; set; }

        [NotNull]
        public string Price { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
