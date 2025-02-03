using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Service.Models
{
    public class MetadataBaseEntityDto : BaseEntityDto
    {
        public string CreatedById { get; set; }
        public BarRatingUserDto CreatedByDto { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
