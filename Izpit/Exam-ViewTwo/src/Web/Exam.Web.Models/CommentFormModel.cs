using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Web.Models
{
    public class CommentFormModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedById { get; set; }
        public int TitleId { get; set;}
    }
}
