namespace GlobalApp.Models
{
    public class Product
    {
        public string ProductTitle { get; set; }
        public string Asin { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string OriginalPrice { get; set; }        
        public string Rating { get; set; }        
        public string TotalRatings { get; set; }               
        public string ProductUrl { get; set; }
        public string ProductImage { get; set; }
        public bool IsPrime { get; set; }
        public bool IsBestSeller { get; set; }
        public bool IsAmazonChoice { get; set; }
    }

    public class ProductSearchResponse
    {
        public string Status { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string Origin { get; set; }
        public string Domain { get; set; }
        public string SortBy { get; set; }

        public List<Product> Details { get; set; }
    }
}
