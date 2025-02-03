using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Data.Models
{
    public class Bar : MetadataBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
