using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
   public  class EmployeePartner
    {
        public int ? pId { get; set; }
        public int ? qrEmpId { get; set; }
        public string pName { get; set; }
        public string pMobile { get; set; }
        public string pAddress { get; set; }
        public string wagesMode { get; set; }
        public string vendorType { get; set; }
        public int  perQrPlate { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<System.DateTime> lastModifyDate { get; set; }

    }
}
