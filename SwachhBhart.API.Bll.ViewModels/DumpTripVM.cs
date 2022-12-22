using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
    public class DumpTripVM
    {
     
        public String transId { get; set; }
        public string startDateTime { get; set; }
        public string endDateTime { get; set; } /// UserTypeID i.e. 0 = Ghanta Gadi, 1 = Scanify , 2 = Waste Management
        public int userId { get; set; }
        public String dyId { get; set; }
        public String [] houseList { get; set; }
        public int tripNo { get; set; }

        public int tNh { get; set; }
        public string vehicleNumber { get; set; }
        public decimal totalGcWeight { get; set; }
        public decimal totalDryWeight { get; set; }
        public decimal totalWetWeight { get; set; }

        public string bcTransId { get; set; }

        public bool TStatus { get; set; }


        public Nullable<long> bcStartDateTime { get; set; }
        public Nullable<long> bcEndDateTime { get; set; }
        public Nullable<decimal> bcTotalGcWeight { get; set; }
        public Nullable<decimal> bcTotalDryWeight { get; set; }
        public Nullable<decimal> bcTotalWetWeight { get; set; }
        public Nullable<System.TimeSpan> tHr { get; set; }
    }
}
