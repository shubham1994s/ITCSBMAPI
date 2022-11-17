using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
   public class EmpComplaintArise
    {
        public int ComplaintAriseId { get; set; }
        public int Userid { get; set; }
        public int ComplaintId { get; set; }
        public string Employeetype { get; set; }
        public Nullable<System.DateTime> PauseDate { get; set; }
        public Nullable<System.DateTime> ResumeDate { get; set; }
    }
}
