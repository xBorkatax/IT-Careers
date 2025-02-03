using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Web.Models
{
    public class ReviewCreationModel
    {
        [Required]
        [Display(Name = "Review text")]
        public string Text { get; set; }

        public string BarName { get; set; }

        public string BarId { get; set; }

        public string CreatedById { get; set; }
    }
}
