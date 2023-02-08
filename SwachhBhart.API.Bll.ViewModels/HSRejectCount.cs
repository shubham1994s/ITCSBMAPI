using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
    public class HSRejectCount
    {
        public Nullable<int> HouseCount { get; set; }
        public Nullable<int> LiquidCount { get; set; }
        public Nullable<int> StreetCount { get; set; }
        public Nullable<int> DumpCount { get; set; }
    }
}
