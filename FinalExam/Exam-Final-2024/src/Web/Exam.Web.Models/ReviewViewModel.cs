using Exam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Web.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BarberId { get; set; }
        public User CreatedBy { get; set; }
    }
}
