using Exam.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Web.Models
{
    public class BarberFormModel
    {
		[Required]
        [StringLength(64, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Description { get; set; }
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public int CreatedById { get; set; }
    }
}
