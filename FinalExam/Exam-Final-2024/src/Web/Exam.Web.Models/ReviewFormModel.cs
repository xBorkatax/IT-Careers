using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Web.Models
{
    public class ReviewFormModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int CreatedById { get; set; }
        public int BarberId { get; set;}
    }
}
