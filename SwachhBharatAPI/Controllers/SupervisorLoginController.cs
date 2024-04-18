using SwachhBharat.API.Bll.Repository.Repository;
using SwachhBhart.API.Bll.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static SwachhBhart.API.Bll.ViewModels.LinkULRModel;

namespace SwachhBharatAPI.Controllers
{
    [RoutePrefix("api/Supervisor")]
    public class SupervisorLoginController : ApiController
    {
        IRepository objRep;

        [Route("Login")]
        [HttpPost]
        public SBUser GetLogin(SBUser objlogin)
        {
            //IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
            //var id = headerValue1.FirstOrDefault();
            //int AppId = int.Parse(id);

            IEnumerable<string> headerValue1 = Request.Headers.GetValues("EmpType");
            var EmpType = headerValue1.FirstOrDefault();

            EmpType = "A";

            objRep = new Repository();
            SBUser objresponse = objRep.CheckSupervisorUserLogin(objlogin.userLoginId, objlogin.userPassword, EmpType);
            return objresponse;
        }

        [HttpGet]
        [Route("AllUlb")]
        public List<NameULB> GetUlb()
        {
            objRep = new Repository();

            IEnumerable<string> headerValue1 = Request.Headers.GetValues("EmpType");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("userId");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("status");
            var EmpType = headerValue1.FirstOrDefault();
            var u = headerValue2.FirstOrDefault();
            int userId = int.Parse(u);
            var Status = headerValue3.FirstOrDefault();
            List<NameULB> objDetail = new List<NameULB>();
            objDetail = objRep.GetUlb(userId, EmpType, Status.ToLower()).ToList();
            return objDetail;
        }


        [HttpGet]
        [Route("SelectedUlb")]
        public HSDashboard GetSelectedUlbData()
        {
            objRep = new Repository();
            IEnumerable<string> headerValue1 = Request.Headers.GetValues("EmpType");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("userId");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);
            var EmpType = headerValue1.FirstOrDefault();
            var u = headerValue2.FirstOrDefault();
            int userId = int.Parse(u);
            var objDetail = objRep.GetSelectedUlbData(userId, EmpType, AppId);
            return objDetail;
        }


        [HttpGet]
        [Route("QREmployeeList")]
        // Active Employee List For Filter
        public List<HSEmployee> GetQREmployeeList()
        {
            objRep = new Repository();

            IEnumerable<string> headerValue1 = Request.Headers.GetValues("EmpType");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("userId");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);
            var EmpType = headerValue1.FirstOrDefault();
            var u = headerValue2.FirstOrDefault();
            int userId = int.Parse(u);
            List<HSEmployee> objDetail = new List<HSEmployee>();
            objDetail = objRep.GetQREmployeeList(userId, EmpType, AppId).ToList();
            return objDetail;
        }

        [HttpGet]
        [Route("QREmployeeDetailsList")]
        public List<HouseScanifyEmployeeDetails> GetQREmployeeDetailsList()
        {
            objRep = new Repository();

            IEnumerable<string> headerValue1 = Request.Headers.GetValues("EmpType");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("userId");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            IEnumerable<string> headerValue4 = Request.Headers.GetValues("qrEmpId");
            IEnumerable<string> headerValue5 = Request.Headers.GetValues("status");

            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);
            var EmpType = headerValue1.FirstOrDefault();
            var u = headerValue2.FirstOrDefault();
            int userId = int.Parse(u);

            var EmpID = headerValue4.FirstOrDefault();
            int QrEmpId = int.Parse(EmpID);

            var s = headerValue5.FirstOrDefault();
            bool status = bool.Parse(s);

            List<HouseScanifyEmployeeDetails> objDetail = new List<HouseScanifyEmployeeDetails>();
            objDetail = objRep.GetQREmployeeDetailsList(userId, EmpType, AppId, QrEmpId, status).ToList();
            return objDetail;
        }

        [HttpGet]
        [Route("HouseScanifyDetailsGridRow")]
        // Show Live Data On Dashboard
        public List<HouseScanifyDetailsGridRow> GetHouseScanifyDetails()
        {
            objRep = new Repository();

            IEnumerable<string> headerValue1 = Request.Headers.GetValues("FromDate");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("Todate");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            IEnumerable<string> headerValue4 = Request.Headers.GetValues("userId");


            var Fdate = headerValue1.FirstOrDefault();
            DateTime FromDate = Convert.ToDateTime(Fdate);

            var Tdate = headerValue2.FirstOrDefault();
            DateTime Todate = Convert.ToDateTime(Tdate);

            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);

            int qrEmpId;
            var u = headerValue4.FirstOrDefault();
            if (u == "null" || u == "" || u == null)
            {
                qrEmpId = 0;
            }
            else
            {
                qrEmpId = int.Parse(u);
            }

            List<HouseScanifyDetailsGridRow> objDetail = new List<HouseScanifyDetailsGridRow>();
            objDetail = objRep.GetHouseScanifyDetails(qrEmpId, FromDate, Todate, AppId).ToList();
            return objDetail;
        }


        [HttpGet]
        [Route("AttendanceGridRow")]
        public List<HSAttendanceGrid> GetAttendanceDetails()
        {
            objRep = new Repository();

            IEnumerable<string> headerValue1 = Request.Headers.GetValues("FromDate");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("Todate");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            IEnumerable<string> headerValue4 = Request.Headers.GetValues("qrEmpId");


            var Fdate = headerValue1.FirstOrDefault();
            DateTime FromDate = Convert.ToDateTime(Fdate);

            var Tdate = headerValue2.FirstOrDefault();
            DateTime Todate = Convert.ToDateTime(Tdate);

            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);

            int userId;
            var u = headerValue4.FirstOrDefault();
            if (u == "null" || u == "" || u == null)
            {
                userId = 0;
            }
            else
            {
                userId = int.Parse(u);
            }

            List<HSAttendanceGrid> objDetail = new List<HSAttendanceGrid>();
            objDetail = objRep.GetAttendanceDetails(userId, FromDate, Todate, AppId).ToList();
            return objDetail;
        }


        [HttpGet]
        [Route("HouseDetails")]
        public List<HSHouseDetailsGrid> GetHouseDetails()
        {
            objRep = new Repository();

            IEnumerable<string> headerValue1 = Request.Headers.GetValues("FromDate");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("Todate");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            IEnumerable<string> headerValue4 = Request.Headers.GetValues("userId");
            IEnumerable<string> headerValue5 = Request.Headers.GetValues("ReferanceId");


            var Fdate = headerValue1.FirstOrDefault();
            DateTime FromDate = Convert.ToDateTime(Fdate);

            var Tdate = headerValue2.FirstOrDefault();
            DateTime Todate = Convert.ToDateTime(Tdate);

            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);

            int userId;
            var u = headerValue4.FirstOrDefault();
            if (u == "null" || u == "" || u == null)
            {
                userId = 0;
            }
            else
            {
                userId = int.Parse(u);
            }

            var ReferanceId = headerValue5.FirstOrDefault();

            List<HSHouseDetailsGrid> objDetail = new List<HSHouseDetailsGrid>();
            objDetail = objRep.GetHouseDetails(userId, FromDate, Todate, AppId, ReferanceId).ToList();
            return objDetail;
        }


        [HttpGet]
        [Route("DumpYardDetails")]
        public List<HSDumpYardDetailsGrid> GetDumpYardDetails()
        {
            objRep = new Repository();

            IEnumerable<string> headerValue1 = Request.Headers.GetValues("FromDate");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("Todate");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            IEnumerable<string> headerValue4 = Request.Headers.GetValues("userId");


            var Fdate = headerValue1.FirstOrDefault();
            DateTime FromDate = Convert.ToDateTime(Fdate);

            var Tdate = headerValue2.FirstOrDefault();
            DateTime Todate = Convert.ToDateTime(Tdate);

            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);

            int userId;
            var u = headerValue4.FirstOrDefault();
            if (u == "null" || u == "" || u == null)
            {
                userId = 0;
            }
            else
            {
                userId = int.Parse(u);
            }

            List<HSDumpYardDetailsGrid> objDetail = new List<HSDumpYardDetailsGrid>();
            objDetail = objRep.GetDumpYardDetails(userId, FromDate, Todate, AppId).ToList();
            return objDetail;
        }


        [HttpGet]
        [Route("LiquidDetails")]
        public List<HSLiquidDetailsGrid> GetLiquidDetails()
        {
            objRep = new Repository();

            IEnumerable<string> headerValue1 = Request.Headers.GetValues("FromDate");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("Todate");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            IEnumerable<string> headerValue4 = Request.Headers.GetValues("userId");


            var Fdate = headerValue1.FirstOrDefault();
            DateTime FromDate = Convert.ToDateTime(Fdate);

            var Tdate = headerValue2.FirstOrDefault();
            DateTime Todate = Convert.ToDateTime(Tdate);

            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);

            int userId;
            var u = headerValue4.FirstOrDefault();
            if (u == "null" || u == "" || u == null)
            {
                userId = 0;
            }
            else
            {
                userId = int.Parse(u);
            }

            List<HSLiquidDetailsGrid> objDetail = new List<HSLiquidDetailsGrid>();
            objDetail = objRep.GetLiquidDetails(userId, FromDate, Todate, AppId).ToList();
            return objDetail;
        }


        [HttpGet]
        [Route("StreetDetails")]
        public List<HSStreetDetailsGrid> GetStreetDetails()
        {
            objRep = new Repository();

            IEnumerable<string> headerValue1 = Request.Headers.GetValues("FromDate");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("Todate");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            IEnumerable<string> headerValue4 = Request.Headers.GetValues("userId");


            var Fdate = headerValue1.FirstOrDefault();
            DateTime FromDate = Convert.ToDateTime(Fdate);

            var Tdate = headerValue2.FirstOrDefault();
            DateTime Todate = Convert.ToDateTime(Tdate);

            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);

            int userId;
            var u = headerValue4.FirstOrDefault();
            if (u == "null" || u == "" || u == null)
            {
                userId = 0;
            }
            else
            {
                userId = int.Parse(u);
            }

            List<HSStreetDetailsGrid> objDetail = new List<HSStreetDetailsGrid>();
            objDetail = objRep.GetStreetDetails(userId, FromDate, Todate, AppId).ToList();
            return objDetail;
        }



        [HttpGet]
        [Route("RejectedHSCount")]
        public List<HSRejectCount> GetRejectedHSCount()
        {
            objRep = new Repository();
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);

            List<HSRejectCount> objDetail = new List<HSRejectCount>();
            objDetail = objRep.GetRejectedHSCount(AppId).ToList();
            return objDetail;
        }


        [HttpGet]
        [Route("RejectedHouseDetails")]
        public List<HSHouseDetailsGrid> GetRejectedHouseDetails()
        {
            objRep = new Repository();
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);

            List<HSHouseDetailsGrid> objDetail = new List<HSHouseDetailsGrid>();
            objDetail = objRep.GetRejectedHouseDetails(AppId).ToList();
            return objDetail;
        }

        [HttpGet]
        [Route("RejectedLiquidDetails")]
        public List<HSLiquidDetailsGrid> GetRejectedLiquidDetails()
        {
            objRep = new Repository();
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);

            List<HSLiquidDetailsGrid> objDetail = new List<HSLiquidDetailsGrid>();
            objDetail = objRep.GetRejectedLiquidDetails(AppId).ToList();
            return objDetail;
        }

        [HttpGet]
        [Route("RejectedStreetDetails")]
        public List<HSStreetDetailsGrid> GetRejectedStreetDetails()
        {
            objRep = new Repository();
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);

            List<HSStreetDetailsGrid> objDetail = new List<HSStreetDetailsGrid>();
            objDetail = objRep.GetRejectedStreetDetails(AppId).ToList();
            return objDetail;
        }

        [HttpGet]
        [Route("RejectedDumpYardDetails")]
        public List<HSDumpYardDetailsGrid> GetRejectedDumpYardDetails()
        {
            objRep = new Repository();
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("appId");
            var id = headerValue3.FirstOrDefault();
            int AppId = int.Parse(id);

            List<HSDumpYardDetailsGrid> objDetail = new List<HSDumpYardDetailsGrid>();
            objDetail = objRep.GetRejectedDumpYardDetails(AppId).ToList();
            return objDetail;
        }



        [HttpGet]
        [Route("UserRoleList")]
        public List<UserRoleDetails> UserRoleList()
        {
            objRep = new Repository();

            IEnumerable<string> headerValue1 = Request.Headers.GetValues("EmpType");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("userId");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("status");
            IEnumerable<string> headerValue4 = Request.Headers.GetValues("EmpId");

            var EmpType = headerValue1.FirstOrDefault();
            var u = headerValue2.FirstOrDefault();
            int userId = int.Parse(u);
            var s = headerValue3.FirstOrDefault();
            bool status = bool.Parse(s);

            var emp = headerValue4.FirstOrDefault();
            int EmpId = int.Parse(emp);

            List<UserRoleDetails> objDetail = new List<UserRoleDetails>();
            objDetail = objRep.UserRoleList(userId, EmpType, status, EmpId).ToList();
            return objDetail;
        }





        [Route("AddHouseScanifyEmployee")]
        [HttpPost]
        public List<CollectionSyncResult> AddEmployee(List<HouseScanifyEmployeeDetails> objRaw)
        {

            objRep = new Repository();
            HouseScanifyEmployeeDetails gcDetail = new HouseScanifyEmployeeDetails();
            List<CollectionSyncResult> objres = new List<CollectionSyncResult>();
            try
            {

                IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
                var AppId = Convert.ToInt32(headerValue1.FirstOrDefault());

                IEnumerable<string> headerValue2 = Request.Headers.GetValues("userId");
                var UserId = Convert.ToInt32(headerValue2.FirstOrDefault());

                foreach (var item in objRaw)
                {
                    gcDetail.qrEmpId = item.qrEmpId;
                    gcDetail.qrEmpName = item.qrEmpName;
                    gcDetail.qrEmpLoginId = item.qrEmpLoginId.Trim();
                    gcDetail.qrEmpPassword = item.qrEmpPassword.Trim();
                    gcDetail.qrEmpMobileNumber = item.qrEmpMobileNumber;
                    gcDetail.qrEmpAddress = item.qrEmpAddress;
                    gcDetail.imoNo = item.imoNo;
                    gcDetail.isActive = item.isActive;
                    gcDetail.isPartner = item.isPartner;




                    CollectionSyncResult detail = objRep.SaveAddEmployee(gcDetail, AppId, UserId);
                    if (detail.message == "")
                    {
                        objres.Add(new CollectionSyncResult()
                        {
                            ID = detail.ID,
                            status = "error",
                            message = "Record not inserted",
                            messageMar = "रेकॉर्ड सबमिट केले नाही"
                        });
                    }

                    objres.Add(new CollectionSyncResult()
                    {

                        status = detail.status,
                        messageMar = detail.messageMar,
                        message = detail.message

                    });

                    return objres;

                }


            }
            catch (Exception ex)
            {

                objres.Add(new CollectionSyncResult()
                {
                    ID = 0,
                    status = "error",
                    message = "Something is wrong,Try Again.. ",
                    messageMar = "काहीतरी चुकीचे आहे, पुन्हा प्रयत्न करा..",
                });
                return objres;

            }

            objres.Add(new CollectionSyncResult()
            {
                ID = 0,
                status = "error",
                message = "Record not inserted",
                messageMar = "रेकॉर्ड सबमिट केले नाही",
            });

            return objres;

        }


        //Partner API
        [Route("AddEmployeePartner")]
        [HttpPost]
        public List<CollectionSyncResult> AddEmployeePartner(List<EmployeePartner>objRaw)
        {
            objRep = new Repository();
            EmployeePartner PDetail = new EmployeePartner();
            List<CollectionSyncResult> objres = new List<CollectionSyncResult>();
            try
            {
                IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
                var AppId = Convert.ToInt32(headerValue1.FirstOrDefault());

                foreach (var item in objRaw)
                {
                    PDetail.pId = item.pId;
                    PDetail.qrEmpId = item.qrEmpId;
                    PDetail.pName = item.pName;                 
                    PDetail.pMobile = item.pMobile;
                    PDetail.pAddress = item.pAddress;
                    PDetail.vendorType = item.vendorType;
                    PDetail.wagesMode = item.wagesMode;
                    PDetail.perQrPlate = item.perQrPlate;
                    PDetail.isActive = item.isActive;

                    CollectionSyncResult detail = objRep.SaveAddEmployeePartner(PDetail, AppId);
                    if (detail.message == "")
                    {
                        objres.Add(new CollectionSyncResult()
                        {
                            ID = detail.ID,
                            status = "error",
                            message = "Record not inserted",
                            messageMar = "रेकॉर्ड सबमिट केले नाही"
                        });
                    }

                    objres.Add(new CollectionSyncResult()
                    {
                        status = detail.status,
                        messageMar = detail.messageMar,
                        message = detail.message
                    });

                    return objres;

                }


            }
            catch (Exception ex)
            {

                objres.Add(new CollectionSyncResult()
                {
                    ID = 0,
                    status = "error",
                    message = "Something is wrong,Try Again.. ",
                    messageMar = "काहीतरी चुकीचे आहे, पुन्हा प्रयत्न करा..",
                });
                return objres;

            }

            objres.Add(new CollectionSyncResult()
            {
                ID = 0,
                status = "error",
                message = "Record not inserted",
                messageMar = "रेकॉर्ड सबमिट केले नाही",
            });

            return objres;

        }

        [HttpGet]
        [Route("EmployeePartnerList")]
        public List<EmployeePartner> GetEmployeePartnerList()
        {
            objRep = new Repository();

            IEnumerable<string> headerValue4 = Request.Headers.GetValues("appId");
            IEnumerable<string> headerValue1 = Request.Headers.GetValues("pId");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("qrEmpId");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("status");

            var app = headerValue4.FirstOrDefault();
            int appid = int.Parse(app);


            var Id = headerValue1.FirstOrDefault();
            int pId;
            if (Id!=null && Id != "")
            {
                 pId = int.Parse(Id);
            }
            else
            {
                 pId = 0;
            }

            var EmpID = headerValue2.FirstOrDefault();
            int qrEmpId;
            if (EmpID != null && EmpID != "")
            {
                qrEmpId = int.Parse(EmpID);
            }
            else
            {
                qrEmpId = 0;
            }

            var s = headerValue3.FirstOrDefault();
            bool status = bool.Parse(s);

            List<EmployeePartner> objDetail = new List<EmployeePartner>();
            objDetail = objRep.GetEmployeePartnerList(appid,pId,qrEmpId,status).ToList();
            return objDetail;
        }


        //END
        [Route("CheckHSURUsername")]
        [HttpGet]
        public CheckHSURUsernameResponse CheckHSURUsername()
        {
            objRep = new Repository();
            CheckHSURUsernameResponse objres = new CheckHSURUsernameResponse();
            try
            {
                IEnumerable<string> headerValue1 = Request.Headers.GetValues("Loginid");

                var Loginid = headerValue1.FirstOrDefault();

                CheckHSURUsernameResponse GetUsername = objRep.GetHSURUsername(Loginid);

                objres.Code = GetUsername.Code;
                objres.Status = GetUsername.Status;
                objres.IsExist = GetUsername.IsExist;
                objres.Message = GetUsername.Message;
                objres.MessageMar = GetUsername.MessageMar;

                return objres;
            }
            catch (WebException ex)
            {

                objres.Code = (int)((HttpWebResponse)ex.Response).StatusCode;
                objres.Status = "error";
                objres.Message = "Something is wrong,Try Again.. ";
                objres.MessageMar = "काहीतरी चुकीचे आहे, पुन्हा प्रयत्न करा..";
                return objres;

            }
        }

        [Route("AddHouseScanifyUserRole")]
        [HttpPost]

        public List<CollectionSyncResult> AddUserRole(List<UserRoleDetails> objRaw)
        {

            objRep = new Repository();
            UserRoleDetails gcDetail = new UserRoleDetails();
            List<CollectionSyncResult> objres = new List<CollectionSyncResult>();
            try
            {

                //IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
                //var AppId = Convert.ToInt32(headerValue1.FirstOrDefault());


                foreach (var item in objRaw)
                {
                    gcDetail.EmpId = item.EmpId;
                    gcDetail.EmpName = item.EmpName;
                    gcDetail.LoginId = item.LoginId.Trim();
                    gcDetail.Password = item.Password.Trim();
                    gcDetail.EmpMobileNumber = item.EmpMobileNumber;
                    gcDetail.EmpAddress = item.EmpAddress;
                    gcDetail.type = item.type;
                    gcDetail.isActive = item.isActive;
                    gcDetail.isActiveULB = item.isActiveULB;
                    //gcDetail.LastModifyDateEntry = item.LastModifyDateEntry;

                    CollectionSyncResult detail = objRep.SaveAddUserRole(gcDetail);
                    if (detail.message == "")
                    {
                        objres.Add(new CollectionSyncResult()
                        {
                            ID = detail.ID,
                            status = "error",
                            message = "Record not inserted",
                            messageMar = "रेकॉर्ड सबमिट केले नाही"
                        });
                    }

                    objres.Add(new CollectionSyncResult()
                    {

                        status = detail.status,
                        messageMar = detail.messageMar,
                        message = detail.message

                    });

                    return objres;

                }


            }
            catch (Exception ex)
            {

                objres.Add(new CollectionSyncResult()
                {
                    ID = 0,
                    status = "error",
                    message = "Something is wrong,Try Again.. ",
                    messageMar = "काहीतरी चुकीचे आहे, पुन्हा प्रयत्न करा..",
                });
                return objres;

            }

            objres.Add(new CollectionSyncResult()
            {
                ID = 0,
                status = "error",
                message = "Record not inserted",
                messageMar = "रेकॉर्ड सबमिट केले नाही",
            });

            return objres;

        }


        [Route("UpdateQRstatus")]
        [HttpPost]
        public List<CollectionQRStatusResult> UpdateQRstatus(List<HSHouseDetailsGrid> objRaw)
        {

            objRep = new Repository();
            HSHouseDetailsGrid gcDetail = new HSHouseDetailsGrid();
            List<CollectionQRStatusResult> objres = new List<CollectionQRStatusResult>();
            try
            {

                IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
                var AppId = Convert.ToInt32(headerValue1.FirstOrDefault());


                foreach (var item in objRaw)
                {

                    gcDetail.QRStatus = item.QRStatus;
                    gcDetail.ReferanceId = item.ReferanceId;
                    CollectionQRStatusResult detail = objRep.UpdateQRstatus(gcDetail, AppId);
                    if (detail.message == "")
                    {
                        objres.Add(new CollectionQRStatusResult()
                        {
                            ReferanceId = detail.ReferanceId,
                            status = "error",
                            message = "Record not inserted",
                            messageMar = "रेकॉर्ड सबमिट केले नाही"
                        });
                    }

                    objres.Add(new CollectionQRStatusResult()
                    {
                        ReferanceId = detail.ReferanceId,
                        status = detail.status,
                        messageMar = detail.messageMar,
                        message = detail.message

                    });

                    return objres;

                }


            }
            catch (Exception ex)
            {

                objres.Add(new CollectionQRStatusResult()
                {
                    ReferanceId = "",
                    status = "error",
                    message = "Something is wrong,Try Again.. ",
                    messageMar = "काहीतरी चुकीचे आहे, पुन्हा प्रयत्न करा..",
                });
                return objres;

            }

            objres.Add(new CollectionQRStatusResult()
            {
                ReferanceId = "",
                status = "error",
                message = "Record not inserted",
                messageMar = "रेकॉर्ड सबमिट केले नाही",
            });

            return objres;

        }

        [HttpPost]
        [Route("SupervisorAttendenceIn")]
        public Result SaveQrEmployeeAttendence(BigVQREmployeeAttendenceVM obj)
        {
            objRep = new Repository();
            Result objDetail = new Result();
            objDetail = objRep.SaveSupervisorAttendence(obj, 0);
            return objDetail;
        }

        [HttpPost]
        [Route("SupervisorAttendenceOut")]
        public Result SaveQrEmployeeAttendenceOut(BigVQREmployeeAttendenceVM obj)
        {
            objRep = new Repository();
            Result objDetail = new Result();
            objDetail = objRep.SaveSupervisorAttendence(obj, 1);
            return objDetail;
        }


        [HttpPost]
        [Route("SupervisorAttendenceCheck")]
        public Result CheckQrEmployeeAttendence(BigVQREmployeeAttendenceVM obj)
        {
            objRep = new Repository();
            Result objDetail = new Result();
            objDetail = objRep.CheckSupervisorAttendence(obj);
            return objDetail;
        }


        [HttpGet]
        [Route("GetHouseList")]
        public List<HouseDetailsVM> GetHouseWise()
        {
            List<HouseDetailsVM> objDetail = new List<HouseDetailsVM>();
            objRep = new Repository();
            IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("ListType");
            var id = headerValue1.FirstOrDefault();
            int AppId = int.Parse(id);
            var ListType = headerValue3.FirstOrDefault();
            objDetail = objRep.GetHouseList(AppId, ListType);
            return objDetail;

        }

        [HttpGet]
        [Route("GetAllHDSLDetails")]
        public List<HSHouseDetailsGrid> GetHouseListById()
        {
            objRep = new Repository();
            IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("ReferanceId");
            var id = headerValue1.FirstOrDefault();
            int AppId = int.Parse(id);
            var EType = headerValue3.FirstOrDefault();
            var EmpType = EType.Substring(0, 1);
            var ReferanceId = headerValue3.FirstOrDefault();
            List<HSHouseDetailsGrid> objDetail = new List<HSHouseDetailsGrid>();
            objDetail = objRep.GetHDSLList(AppId, EmpType, ReferanceId);
            return objDetail;

        }

        [HttpGet]
        [Route("GetUserRoleAttendance")]
        public List<UREmployeeAttendence> UserRoleAttendance()
        {


            IEnumerable<string> headerValue1 = Request.Headers.GetValues("FromDate");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("Todate");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("userId");

            var Fdate = headerValue1.FirstOrDefault();
            DateTime FromDate = Convert.ToDateTime(Fdate);

            var Tdate = headerValue2.FirstOrDefault();
            DateTime Todate = Convert.ToDateTime(Tdate);

            int userId;
            var u = headerValue3.FirstOrDefault();
            if (u == "null" || u == "" || u == null)
            {
                userId = 0;
            }
            else
            {
                userId = int.Parse(u);
            }

            IEnumerable<string> headerValue4 = Request.Headers.GetValues("IsMobile");
            var type = (headerValue4.FirstOrDefault());
            bool IsMobile = bool.Parse(type);
            objRep = new Repository();
            List<UREmployeeAttendence> objDetail = new List<UREmployeeAttendence>();
            objDetail = objRep.UserRoleAttendance(userId, FromDate, Todate, IsMobile).ToList();
            return objDetail;
        }


        [HttpGet]
        [Route("GetPropertyCount")]
        public List<PropertyScanModel> TotalPropertyCount()
        {
            int userId = 0;
            List<PropertyScanModel> objDetail = new List<PropertyScanModel>();
            IEnumerable<string> headerValue1 = Request.Headers.GetValues("userId");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("empType");
            IEnumerable<string> headerValue3 = Request.Headers.GetValues("fDate");

            var u = headerValue1.FirstOrDefault();
            if (!string.IsNullOrEmpty(u))
            {
               userId = int.Parse(u);
            }
            var empType = headerValue2.FirstOrDefault();

            var Fdate = headerValue3.FirstOrDefault();
            DateTime FromDate;
            if (!string.IsNullOrEmpty(Fdate))
            {
                 FromDate = Convert.ToDateTime(Fdate);
            }
            else
            {
                 FromDate = DateTime.Now;
            }
            

            objRep = new Repository();
            objDetail = objRep.GetTotalPropertyCount(userId, empType, FromDate).ToList();
            return objDetail;
        }

        [HttpGet]
        [Route("GetLinkURL")]
        public List<LinkRoot> LinkURL()
        {
            List<LinkRoot> objDetail = new List<LinkRoot>();
            IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
            var AppId = Convert.ToInt32(headerValue1.FirstOrDefault());
            if (AppId!=0)
            {
                objRep = new Repository();
                objDetail = objRep.GetLinkURL(AppId).ToList();
            }
           
            return objDetail;
        }

    }
}
