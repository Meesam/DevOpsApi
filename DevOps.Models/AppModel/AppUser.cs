using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Models.AppModel
{
    public class AppUser: IdentityUser
    {
        [Required]
        [MaxLength(200)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(200)]
        public string? LastName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public List<Project> UserProjects { get; set; } = new List<Project>();
        public List<Address> UserAddresses { get; set; } = new List<Address>();
        public List<EmailAddress> UserEmailAddress { get; set; } = new List<EmailAddress>();
    }
}
