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
    
    public partial class GarbagePointDetail
    {
        public int gpId { get; set; }
        public string gpName { get; set; }
        public string gpNameMar { get; set; }
        public string gpLat { get; set; }
        public string gpLong { get; set; }
        public string qrCode { get; set; }
        public Nullable<int> zoneId { get; set; }
        public Nullable<int> wardId { get; set; }
        public Nullable<int> areaId { get; set; }
        public string ReferanceId { get; set; }
        public string gpAddress { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public Nullable<int> userId { get; set; }
    }
}
