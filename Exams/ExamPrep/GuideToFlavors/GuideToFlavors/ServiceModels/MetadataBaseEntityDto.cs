namespace GuideToFlavors.ServiceModels
{
    public class MetadataBaseEntityDto : BaseEntityDto
    {
        public GuideToFlavorsUserDto CreatedByDto { get; set; } = new GuideToFlavorsUserDto();

        public string? CreatedById { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
