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
    
    public partial class TransDumpTD
    {
        public int TransBcId { get; set; }
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
        public string bcTransId { get; set; }
        public Nullable<bool> TStatus { get; set; }
        public Nullable<long> bcStartDateTime { get; set; }
        public Nullable<long> bcEndDateTime { get; set; }
        public Nullable<long> bcTotalGcWeight { get; set; }
        public Nullable<long> bcTotalDryWeight { get; set; }
        public Nullable<long> bcTotalWetWeight { get; set; }
        public Nullable<System.TimeSpan> tHr { get; set; }
        public Nullable<int> tNh { get; set; }
        public Nullable<long> bcThr { get; set; }
        public Nullable<decimal> UsTotalGcWeight { get; set; }
        public Nullable<decimal> UsTotalDryWeight { get; set; }
        public Nullable<decimal> UsTotalWetWeight { get; set; }
        public Nullable<decimal> TotalGcWeightKg { get; set; }
        public Nullable<decimal> TotalDryWeightKg { get; set; }
        public Nullable<decimal> TotalWetWeightKg { get; set; }
        public Nullable<System.DateTime> Date_Time { get; set; }
    }
}
