using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Web.Models
{
    public class BarCreationModel
    {
        [Required]
        [StringLength(64, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [Display(Name = "Bar name")]
        public string Name { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [Display(Name = "Bar description")]
        public string Description { get; set; }

        [Display(Name = "Bar image")]
        public IFormFile Image { get; set; }

        public string CreatedById { get; set; }
    }
}
