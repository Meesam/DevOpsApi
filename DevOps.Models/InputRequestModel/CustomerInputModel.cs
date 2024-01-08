using DevOps.Models.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Models.InputRequestModel
{
    public class CustomerInputModel
    {
       public List<Contacts> CustomerContactsInfo { get; set; } = new List<Contacts>();
       public Customer CustomerBasicInfo { get; set; } = new Customer();
    
    }
}
