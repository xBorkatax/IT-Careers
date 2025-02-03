using System.ComponentModel.DataAnnotations;

namespace GuideToFlavors.Models.Restaurant
{
	public class RestaurantCreationModel
	{
		[Required]
		[StringLength(64, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
		[Display(Name = "Restaurant name")]
		public string Name { get; set; }

		[Required]
		[StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
		[Display(Name = "Restaurant description")]
		public string Description { get; set; }

		[Display(Name = "Restaurant image")]
		public IFormFile Image { get; set; }
	}
}
