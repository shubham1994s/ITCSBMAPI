//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SwachhBharatAPI.Dal.DataContexts
{
    using System;
    using System.Collections.Generic;
    
    public partial class DumpTripDetailM
    {
        public int tripId { get; set; }
        public string transId { get; set; }
        public Nullable<System.DateTime> startDateTime { get; set; }
        public Nullable<System.DateTime> endDateTime { get; set; }
        public Nullable<int> userId { get; set; }
        public string dyId { get; set; }
        public string houseList { get; set; }
        public Nullable<int> tripNo { get; set; }
        public string vehicleNumber { get; set; }
        public Nullable<decimal> totalGcWeight { get; set; }
        public Nullable<decimal> totalDryWeight { get; set; }
        public Nullable<decimal> totalWetWeight { get; set; }
    }
}
