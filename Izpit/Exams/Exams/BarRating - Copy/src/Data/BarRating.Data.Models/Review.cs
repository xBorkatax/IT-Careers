using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Data.Models
{
    public class Review : MetadataBaseEntity
    {
        public string Text { get; set; }

        [ForeignKey(nameof(Bar))]
        public string BarId { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Bar Bar { get; set; }
    }
}
