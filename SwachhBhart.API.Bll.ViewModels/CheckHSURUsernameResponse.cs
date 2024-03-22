using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
   public class CheckHSURUsernameResponse
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public int IsExist { get; set; }
        public string Message { get; set; }
        public string MessageMar { get; set; }
    }
}
