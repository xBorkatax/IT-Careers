namespace GuideToFlavors.ServiceModels
{
    public class ReviewDto : MetadataBaseEntityDto
    {
        public string? Text { get; set; }
        
        public RestaurantDto? RestaurantDto { get; set; }
        
        public string? RestaurantId { get; set; }
    }
}
