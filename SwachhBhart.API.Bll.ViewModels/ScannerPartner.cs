using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
    public class ScannerPartner
    {
        public string startDate { get; set; }
        public string scannerEmpCode { get; set; }
        public string scannerName { get; set; }
        public string scannerMob { get; set; }
        public string partnerEmpCode { get; set; }
        public string partnerName { get; set; }
        public string partnerMob { get; set; }
        public Nullable<int> houseCount { get; set; }
        public Nullable<int> liquidCount { get; set; }
        public Nullable<int> streetCount { get; set; }
        public Nullable<int> dumpCount { get; set; }
    }
}
