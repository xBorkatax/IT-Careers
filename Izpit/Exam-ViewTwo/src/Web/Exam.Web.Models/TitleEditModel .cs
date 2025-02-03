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
    public class TitleEditModel
    {
        public int Id { get; set; } 
		[Required]
		public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public User CreatedBy { get; set; }
    }
}
