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
    
    public partial class ComplaintArise
    {
        public int CAId { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<int> Cid { get; set; }
        public Nullable<System.DateTime> PauseDate { get; set; }
        public Nullable<System.DateTime> ResumeDate { get; set; }
        public string EmployeeType { get; set; }
    }
}
