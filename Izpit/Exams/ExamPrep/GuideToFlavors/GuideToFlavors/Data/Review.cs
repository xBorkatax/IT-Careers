using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuideToFlavors.Data
{
	public class Review : MetadataBaseEntity
	{
		[DeleteBehavior(DeleteBehavior.Restrict)]
		public Restaurant Restaurant { get; set; }

		[ForeignKey(nameof(Restaurant))]
		public string RestaurantId { get; set; }

		public string Text { get; set; }
	}
}
