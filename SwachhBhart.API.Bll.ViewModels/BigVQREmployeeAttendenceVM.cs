﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
    public class BigVQREmployeeAttendenceVM
    {
        public int qrEmpDaId { get; set; }
        public Nullable<int> qrEmpId { get; set; }
        public string startLat { get; set; }
        public string startLong { get; set; }
        public string endLat { get; set; }
        public string endLong { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public string startNote { get; set; }
        public string endNote { get; set; }
        public string batteryStatus { get; set; }
        public string OutbatteryStatus { get; set; }
        public int OfflineId { get; set; }
        public string EmployeeType { get; set; }

        public string IpAddress { get; set; }
        public string LoginDevice { get; set; }
        public string HostName { get; set; }

        public string startDate1 { get; set; }
        public string endDate1 { get; set; }

    }

}
