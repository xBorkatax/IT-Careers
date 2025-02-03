using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Models
{
    public class MetadataBaseEntity : BaseEntity
    {
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User CreatedBy { get; set; } = null!;

        [ForeignKey(nameof(CreatedBy))]
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }

        public MetadataBaseEntity()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
