using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Models.AppModel
{
    public class Customer : DateTimeClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Website { get; set; }

        [Required]
        [MaxLength(255)]
        public string? LogoUrl { get; set; }

        public string? Description { get; set; }

        public List<Contacts> ContactsList { get; set; } = new List<Contacts>();

        public List<Project> Projects { get; set; } = new List<Project> { };

        public List<AppMenu> AppMenus { get; set; } = new List<AppMenu> { };
    }
}
