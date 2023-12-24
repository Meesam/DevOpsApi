using DevOps.Models.AppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Models.InputRequestModel
{
    public class ProjectInput:Project
    {
        [Required]
        public string? AppUserId { get; set; }

        [Required]
        public int CustomerId { get; set;}
    }
}
