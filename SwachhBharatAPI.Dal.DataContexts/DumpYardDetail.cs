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
    
    public partial class DumpYardDetail
    {
        public int dyId { get; set; }
        public string dyName { get; set; }
        public string dyNameMar { get; set; }
        public string dyLat { get; set; }
        public string dyLong { get; set; }
        public string dyQRCode { get; set; }
        public Nullable<int> zoneId { get; set; }
        public Nullable<int> wardId { get; set; }
        public Nullable<int> areaId { get; set; }
        public string ReferanceId { get; set; }
        public string dyAddress { get; set; }
        public Nullable<System.DateTime> lastModifiedDate { get; set; }
        public Nullable<int> userId { get; set; }
        public string EmployeeType { get; set; }
    }
}
