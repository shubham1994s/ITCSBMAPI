using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
   public class PropertyScanModel
    {
        public int srNo { get; set; }
        public string appName { get; set; }
        public string houseCount { get; set; }
        public string dumpYardCount { get; set; }
        public string liquidCount { get; set; }
        public string streetCount { get; set; }
    }
}
