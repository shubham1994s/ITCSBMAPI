﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
   public class HSLiquidDetailsGrid
    {

        public int LWId { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string ReferanceId { get; set; }
        public string Name { get; set; }
        public string QRCodeImage { get; set; }
        public string modifiedDate { get; set; }
        public int totalRowCount { get; set; }

        public Nullable<bool> QRStatus { get; set; }

        public Nullable<System.DateTime> QRStatusDate { get; set; }
        public string Remark { get; set; }
    }

}
