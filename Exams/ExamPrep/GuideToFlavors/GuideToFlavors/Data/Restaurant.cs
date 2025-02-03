namespace GuideToFlavors.Data
{
	public class Restaurant : MetadataBaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public byte[] Image { get; set; }
		public List<Review> Reviews { get; set; }
	}
}
