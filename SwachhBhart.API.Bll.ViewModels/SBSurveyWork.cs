using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
    public class SBSurveyWork
    {
        public string date { get; set; }
        public int houseCollection { get; set; }
    }

    public class SBSurveyWorkDetails
    {
        public string time { get; set; }
        public string Date { get; set; }
        public string HouseNo { get; set; }

    }
}
