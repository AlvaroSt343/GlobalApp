namespace GlobalApp.Models
{
    public class ProductDetail
    {
        public string ASIN { get; set; }
        public string ProductTitle { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string DiscountPercentage { get; set; }
        public string OriginalPrice { get; set; }
        public string Brand { get; set; }
        public string Rating { get; set; }
        public string RatingNumber { get; set; }
        public string SellerName { get; set; }
        public string Availability { get; set; }
        public bool IsBestSeller { get; set; }
        public bool IsAmazonFulfilled { get; set; }
        public List<string> Images { get; set; }
        public List<string> Videos { get; set; }
        public List<string> AboutThisItem { get; set; }
        public ProductDetails Details { get; set; }
        public string Variations { get; set; }
        public string CustomersSay { get; set; }
    }

    public class ProductDetails
    {
        public string ReleaseDate { get; set; }
        public string BestSellersRank { get; set; }
        public string ProductDimensions { get; set; }
        public string TypeOfItem { get; set; }
        public string Language { get; set; }
        public string ItemModelNumber { get; set; }
        public string ItemWeight { get; set; }
        public string Manufacturer { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Batteries { get; set; }
        public string DateFirstAvailable { get; set; }
    }

    public class ProductDetailResponse
    {
        public string Status { get; set; }
        public string Currency { get; set; }
        public string Origin { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string DiscountPercentage { get; set; }
        public string OriginalPrice { get; set; }
        public string Brand { get; set; }
        public string Rating { get; set; }
        public string RatingNumber { get; set; }
        public string SellerName { get; set; }
        public string Availability { get; set; }
        public bool BestSeller { get; set; }
        public bool AmazonFulfilled { get; set; }
        public List<string> Images { get; set; }
        public List<string> Videos { get; set; }
        public List<string> AboutThisItem { get; set; }
        public ProductDetails Details { get; set; }
        public string Variations { get; set; }
        public string CustomersSay { get; set; }
    }
}
