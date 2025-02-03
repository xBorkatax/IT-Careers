using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Models
{
    public class Review : MetadataBaseEntity
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public int BarberId { get; set; }
    }
}
