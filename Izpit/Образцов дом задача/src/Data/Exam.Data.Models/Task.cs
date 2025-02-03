using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Models
{
	public class Task : MetadataBaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int LocationId { get; set; }
		public DateTime EndDate {  get; set; }
		public decimal Budget {  get; set; }
		public int CategoryId {  get; set; }
		public int StatusId {  get; set; } 
	}
}
