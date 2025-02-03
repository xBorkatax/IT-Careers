using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Web.Models
{
    public class TaskEditModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
		[Column(TypeName = "Date")]
		[DataType(DataType.Date)]
		public DateTime EndDate { get; set; }
        [Required]
        public decimal Budget { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public int CreatedById { get; set; }
    }
}
