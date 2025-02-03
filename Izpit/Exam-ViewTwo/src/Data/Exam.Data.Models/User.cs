using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Models
{
    public class User : IdentityUser<int>
    {
        [StringLength(20)]
        public string? FirstName { get; set; }

        [StringLength(20)]
        public string? LastName { get; set; }
        public DateTime DateOfCreation { get; set; }

		public bool IsBanned { get; set; }
		public string ProfilePictureUrl { get; set; } = string.Empty;
		public User()
        {
            DateOfCreation = DateTime.Now;
        }
    }
}
