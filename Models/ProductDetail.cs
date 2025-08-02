namespace GlobalApp.Models
{
    public class ProductDetail
    {
        public string Rank { get; set; }
        public string Asin { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
        public string Rating { get; set; }
        public string RatingNum { get; set; }
    }

    public class ProductDetailResponse
    {
        public string Status { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string Origin { get; set; }
        public string Domain { get; set; }
        public string BestSellerCategory { get; set; }
        public List<ProductDetail> Products { get; set; }
    }
}
