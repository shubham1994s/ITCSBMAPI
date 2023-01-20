using SwachhBharat.API.Bll.Repository.Repository;
using SwachhBhart.API.Bll.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLog;
using System.IO;
using NLog.Targets;

namespace SwachhBharatAPI.Controllers
{
    [RoutePrefix("api/Account")]
    public class LoginController : ApiController
    {
       IRepository objRep;
       private static Logger logger = LogManager.GetCurrentClassLogger();
  


        //  private static ILogger<LoginController> _logger;
        //public Action Index()
        //{
        //   // ViewBag.Title = "Home Page";
        //    logger.Info("Hell You have visited the Index view" + Environment.NewLine + DateTime.Now);
        //  //  return View();
        //}
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your app description page.";
        //    logger.Info("hello now You have visited the About view" + Environment.NewLine + DateTime.Now);
        //    return View();
        //}
        // GET: api/users

        // [Authorize]
        [Route("Login")]
        [HttpPost]
        public SBUser GetLogin(SBUser objlogin)
        {
            int AppId = 0;
            SBUser objresponse = new SBUser();
            try
            {
                IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
            var id = headerValue1.FirstOrDefault();
             AppId = int.Parse(id);

            IEnumerable<string> headerValue2 = Request.Headers.GetValues("EmpType");
            var EmpType = headerValue2.FirstOrDefault();

            //    Session["AppId"] = AppId;
                objRep = new Repository();
           
                 objresponse = objRep.CheckUserLogin(objlogin.userLoginId, objlogin.userPassword, objlogin.imiNo, AppId,EmpType);
               
            }
            catch(Exception ex)
            {
                logger.Properties["AppId"] = AppId;
                logger.Error(ex.Message + Environment.NewLine + DateTime.Now + Url.Request);
            }
            
            return objresponse;
        }

        //Added By Saurbh
        // GET: api/admins
        [Route("AdminLogin")]
        [HttpPost]
        public SBAdmin GetAdminLogin(SBAdmin objadminlogin)
        {
            //IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
            //var id = headerValue1.FirstOrDefault();
            //int AppId = int.Parse(id);
            
            objRep = new Repository();

            SBAdmin objresponse = objRep.CheckAdminLogin(objadminlogin.adminLoginId,objadminlogin.adminPassword);
            return objresponse;
        }


        ////Added By Saurbh (16 May 19)
        //// GET: api/admins
        //[Route("EmployeeLogin")]
        //[HttpPost]
        //public BigVQrEmployeeVM GetQrEmployeeLogin(BigVQrEmployeeVM objEmployeeLogin)
        //{
        //    //IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
        //    //var id = headerValue1.FirstOrDefault();
        //    //int AppId = int.Parse(id);

        //    objRep = new Repository();

        //    BigVQrEmployeeVM objresponse = objRep.CheckQrEmployeeLogin(objEmployeeLogin.qrEmpLoginId, objEmployeeLogin.qrEmpPassword);
        //    return objresponse;
        //}
    }
}
