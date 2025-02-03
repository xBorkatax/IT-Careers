using Exam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Web.Models
{
	public class TaskViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int LocationId { get; set; }
		public DateTime EndDate { get; set; }
		public decimal Budget { get; set; }
		public int CategoryId { get; set; }
		public int StatusId { get; set; }
		public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
