namespace GuideToFlavors.ServiceModels
{
    public class RestaurantDto : MetadataBaseEntityDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public byte[]? Image { get; set; }

        public List<ReviewDto>? ReviewDtos { get; set; }
    }
}
