using Exam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Web.Models
{
	public class LocationViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public User CreatedBy { get; set; }
	}
}
