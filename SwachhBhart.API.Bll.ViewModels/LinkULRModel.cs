using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
   public  class LinkULRModel
    {
      
        public class LinkRoot
        {
            public DashboardLink dashboardLink { get; set; }
            public MapLink mapLink { get; set; }

        }
        public class DashboardLink
        {
            public string wasteDashboardLink { get; set; }
            public string liquidDashboardLink { get; set; }
            public string streetDashboardLink { get; set; }
        }

        public class MapLink
        {
            public string wasteMapLink { get; set; }
            public string liquidMapLink { get; set; }
            public string streetMapLink { get; set; }
        }

       

    }
}
