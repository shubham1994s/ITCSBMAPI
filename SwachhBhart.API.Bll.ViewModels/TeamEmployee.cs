using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
    public class TeamEmployee
    {
        public int qrEmpId { get; set; }
        public string qrEmpName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isPartner { get; set; }
    }
}
