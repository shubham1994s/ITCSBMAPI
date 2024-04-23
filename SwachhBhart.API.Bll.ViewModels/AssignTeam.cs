using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
   public class AssignTeam
    {
        public int? Id { get; set; }
        public int? scanEmpId { get; set; }
        public int? partnerEmpId { get; set; }
        public int? userId { get; set; }
        public Nullable<bool> isActive { get; set; }

    }
}
