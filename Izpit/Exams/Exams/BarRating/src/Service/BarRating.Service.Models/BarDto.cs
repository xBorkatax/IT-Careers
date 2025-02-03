using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Service.Models
{
    public class BarDto : MetadataBaseEntityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public List<ReviewDto> ReviewDtos { get; set; }
    }
}
