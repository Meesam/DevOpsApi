using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Models.Response
{
    public class ProjectResponse
    {
      public int ProjectId { get; set; }
      public int CustomerId { get; set; }
      public string CustomerName { get; set; } = string.Empty;
      public string ProjectName { get; set; } = string.Empty;
      public string ProjectDescription { get; set; } = string.Empty;
      public string ProjectType { get; set; } = string.Empty;
      public DateTime ProjectStartDate { get; set; }
      public DateTime? ProjectEndDate { get; set; }
      public string ProjectStatus { get; set; } = string.Empty;
     

    }
}
