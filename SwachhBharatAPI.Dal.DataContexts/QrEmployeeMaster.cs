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
    
    public partial class QrEmployeeMaster
    {
        public int qrEmpId { get; set; }
        public Nullable<int> appId { get; set; }
        public string qrEmpName { get; set; }
        public string qrEmpNameMar { get; set; }
        public string qrEmpLoginId { get; set; }
        public string qrEmpPassword { get; set; }
        public string qrEmpMobileNumber { get; set; }
        public string qrEmpAddress { get; set; }
        public string type { get; set; }
        public Nullable<int> typeId { get; set; }
        public string userEmployeeNo { get; set; }
        public string imoNo { get; set; }
        public string bloodGroup { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string target { get; set; }
        public Nullable<System.DateTime> lastModifyDate { get; set; }
        public Nullable<bool> IsPartner { get; set; }
    }
}
