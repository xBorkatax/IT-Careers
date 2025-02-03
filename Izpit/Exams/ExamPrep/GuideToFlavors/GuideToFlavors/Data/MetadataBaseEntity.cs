using GuideToFlavors.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuideToFlavors.Data
{
	public class MetadataBaseEntity : BaseEntity
	{
		[DeleteBehavior(DeleteBehavior.Restrict)]
		public GuideToFlavorsUser CreatedBy { get; set; }

		[ForeignKey(nameof(CreatedBy))]
		public string CreatedById { get; set; }

		public DateTime CreatedOn { get; set; } = DateTime.Now;
	}
}
