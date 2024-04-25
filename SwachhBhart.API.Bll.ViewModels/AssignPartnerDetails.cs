using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
   public  class AssignPartnerDetails
    {
        public int? id { get; set; }

        public int? sId { get; set; }
        public int? pId { get; set; }
        public int? cId { get; set; }
       
        public string scannerName { get; set; }
        public string partnerName { get; set; }
        public string creatorName { get; set; }

        public Nullable<bool> isActive { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
    }
}
