using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Web.Models
{
    public class BarViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
