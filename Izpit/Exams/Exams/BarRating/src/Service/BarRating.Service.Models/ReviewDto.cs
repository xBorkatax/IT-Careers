using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Service.Models
{
    public class ReviewDto : MetadataBaseEntityDto
    {
        public string Text { get; set; }

        public BarDto BarDto { get; set; }

        public string BarId { get; set; }
    }
}
