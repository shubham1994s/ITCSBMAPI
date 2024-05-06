using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
   public  class HS_ForceUpdateResult
    {
        
        public string status { get; set; }
        public string applink { get; set; }
        public bool? isForceUpdate { get; set; }
        public int? version { get; set; }
    }
}
