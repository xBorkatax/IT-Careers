using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Web.Models
{
	public class TaskFormModel
	{
		[Required]
		public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Budget { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public int CreatedById { get; set; }
	}
}
