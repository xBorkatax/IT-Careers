using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Data.Models
{
    public class MetadataBaseEntity : BaseEntity
    {
        [ForeignKey(nameof(CreatedBy))]
        public string CreatedById { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public BarRatingUser CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
