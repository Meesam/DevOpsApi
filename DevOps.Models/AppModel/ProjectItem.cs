using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Models.AppModel
{
    public class ProjectItem:DateTimeClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string? ItemType { get; set; }

        [Required]
        [MaxLength(50)]
        public string? ItemStatus { get; set; }

        [Required]
        public int ParentItem { get; set; }

        [Required]
        public DateTime? ItemStartDate { get; set; }

        public DateTime? ItemEndDate { get; set; }
    }
}
