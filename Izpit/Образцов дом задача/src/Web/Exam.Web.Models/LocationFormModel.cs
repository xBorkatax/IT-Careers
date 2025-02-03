using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Web.Models
{
	public class LocationFormModel
	{
		[Required]
		public string Name { get; set; }
        [Required]
        public string Address { get; set; }
		public int CreatedById { get; set; }
	}
}
