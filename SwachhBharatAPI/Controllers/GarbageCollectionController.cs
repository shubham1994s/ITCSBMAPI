﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SwachhBharat.API.Bll.Repository;
using SwachhBhart.API.Bll.ViewModels;
using System.IO;
using System.Collections.Specialized;
using SwachhBharat.API.Bll.Repository.Repository;
using SwachhBharatAPI.Dal.DataContexts;
using System.Threading.Tasks;
using SwachhBharatAPI.Models;
using System.Threading;
using Newtonsoft.Json;

using System.Net.Http.Headers;
using System.Globalization;

namespace SwachhBharatAPI.Controllers
{
    [RoutePrefix("api")]
    public class GarbageCollectionController : ApiController
    {
        IRepository _RepositoryApi;
        DevSwachhBharatMainEntities dbMain = new DevSwachhBharatMainEntities();       
        [HttpPost]
        [Route("Save/GarbageCollection")]
        public async Task<CollectionResult> MediaUpload1()
        {
            
            _RepositoryApi = new Repository();
            SBGarbageCollectionView gcDetail = new SBGarbageCollectionView();
            CollectionResult objres = new CollectionResult();
            IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
            IEnumerable<string> headervalue2 = Request.Headers.GetValues("batteryStatus");
            var batteryStatus = headervalue2.FirstOrDefault().ToString();
            //int batteryStatus = int.Parse(battery);
            string[] impath = new string[2];
            string[] arr = new string[4];
            int i = 0;
            try
            {
                string imagePath, FileName;

                var AppId = Convert.ToInt32(headerValue1.FirstOrDefault());
        
                var objmain = dbMain.AppDetails.Where(x => x.AppId == AppId).FirstOrDefault();
                var AppDetailURL = objmain.baseImageUrl + objmain.basePath + objmain.Collection + "/";

                // Check if the request contains multipart/form-data.
                //if (!Request.Content.IsMimeMultipartContent())
                //{
                //    objres.status = "Failed";
                //    objres.message = (new HttpResponseException(HttpStatusCode.UnsupportedMediaType)).ToString();
                //    return objres;
                //}
                var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());
                //access form data
                NameValueCollection formData = provider.FormData;
                //access files
                IList<HttpContent> files = provider.Files;
                HttpContent file1, file2;
                impath = new string[files.Count];
                string Source = AppDetailURL;
                bool exist = Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(objmain.basePath + objmain.Collection));
                if (!exist)
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(objmain.basePath + objmain.Collection));

                //access files
                //string filename = String.Empty;
                if (files.Count == 0)
                {
                    file1 = null;
                    imagePath = "";
                    FileName = "";
                }
                else
                {
                    foreach (var item in files)
                    {
                        string Fil = item.Headers.ContentDisposition.FileName.Trim('\"');
                        FileName = string.Join("", Fil.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

                        imagePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(objmain.basePath + objmain.Collection + "/" + FileName));
                        impath[i] = FileName;
                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }
                        Stream input = await item.ReadAsStreamAsync();
                        using (Stream file3 = File.OpenWrite(imagePath))
                        {
                            input.CopyTo(file3);
                            //close file
                            file3.Close();
                        }
                        //  objRep.UploadFileToFTP(imagePath, SUser);
                        i++;
                    }

                }
                string Filepath = Source;


                gcDetail.userId = int.Parse(formData["userId"]);               
                if (formData["houseId"] == null)
                {
                    gcDetail.houseId = "";
                }
                else {
                    gcDetail.houseId = formData["houseId"];
                    gcDetail.gcType = 1;
                }
                if (formData["gpId"] ==null)
                {
                    gcDetail.gpId = "";
                }
                else {
                    gcDetail.gpId = formData["gpId"];
                    gcDetail.gcType = 2;
                }               
                gcDetail.Lat = formData["Lat"];
                gcDetail.Long = formData["Long"];
                gcDetail.note = formData["note"];
                gcDetail.garbageType =Convert.ToInt32( formData["garbageType"]);
                gcDetail.vehicleNumber = formData["vehicleNumber"];
                // gcDetail.gcDate = Convert.ToString(formData["gcDate"]);             
                string imageStart = "", imageEnd = "";
                imageStart = Convert.ToString(formData["beforeImage"]);
                imageEnd = Convert.ToString(formData["AfterImage"]);
                string Image = "";
                if (impath.Length == 0 || impath[0] == null)
                {
                    gcDetail.gpBeforImage = "";
                    gcDetail.gpAfterImage = "";                    
                }
                else
                {
                    if (imageStart == "" || imageStart == string.Empty || imageStart == null)
                    {
                       gcDetail.gpBeforImage = "";
                        if (imageEnd != "" || imageEnd != string.Empty || imageEnd != null)

                        {
                            gcDetail.gpAfterImage= impath[0];
                        }
                    }
                    else
                    {
                        gcDetail.gpBeforImage = impath[0];


                        if (impath.Length == 0 || i <= 1)
                        {
                            gcDetail.gpAfterImage= "";
                        }
                        else
                        {
                            if (imageEnd != "" || imageEnd != string.Empty || imageEnd != null)

                            {
                                gcDetail.gpAfterImage = impath[1];
                            }
                        }
                    }
                }
                CollectionResult detail = _RepositoryApi.SaveGarbageCollection(gcDetail,AppId,0, batteryStatus);
                if (detail.message == "")
                {
                    objres.name = "";
                    objres.status = "error";
                    objres.message = "Record not inserted";
                    objres.messageMar = "रेकॉर्ड सबमिट केले नाही";
                    return objres;
                }
                objres.name = detail.name;
                objres.status = detail.status;
                objres.messageMar = detail.messageMar;
                objres.message = detail.message;
                objres.mobile = detail.mobile;
                objres.nameMar = detail.nameMar;
                objres.isAttendenceOff = detail.isAttendenceOff;
                return objres;
            }
            catch (Exception ee)
            {
                objres.mobile = "";
                objres.nameMar = "";
                objres.name = "";
                objres.status = "error";
                objres.message = "Something is wrong,Try Again.. ";
                objres.messageMar = "काहीतरी चुकीचे आहे, पुन्हा प्रयत्न करा..";
            }
            objres.mobile = "";
            objres.nameMar = "";
            objres.name = "";
            objres.status = "error";
            objres.message = "Record not inserted";
            objres.messageMar = "रेकॉर्ड सबमिट केले नाही";
            return objres;
        }

        [HttpGet]
        [Route("Get/GarbageCollection")]
        //api/BookATable/GetBookAtableList
        public List<SBGarbageCollectionView> GetComplaintType()
            {
            _RepositoryApi = new Repository();
            IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
            IEnumerable<string> headerValue2 = Request.Headers.GetValues("fdate");
            var id = headerValue1.FirstOrDefault();
            int AppId = int.Parse(id);
            var date= headerValue2.FirstOrDefault();
            DateTime fdate = Convert.ToDateTime(date);
            List<SBGarbageCollectionView> objDetail = new List<SBGarbageCollectionView>();
            objDetail = _RepositoryApi.GetGarbageCollection(fdate,AppId);
            return objDetail;
        }

        [HttpPost]
        [Route("Save/GarbageCollectionOfflineUpload")]
        public List<CollectionSyncResult> OfflineUpload(List<SBGarbageCollectionView> objRaw)
        {

            _RepositoryApi = new Repository();
            SBGarbageCollectionView gcDetail = new SBGarbageCollectionView();
            List<CollectionSyncResult> objres = new List<CollectionSyncResult>();
            IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
            IEnumerable<string> headervalue2 = Request.Headers.GetValues("batteryStatus");
            //IEnumerable<string> headervalue3 = Request.Headers.GetValues("typeId");
            var batteryStatus = headervalue2.FirstOrDefault().ToString();
            int _batteryStatus = int.Parse(batteryStatus);
            //var typeId = headervalue3.FirstOrDefault().ToString();
            //int _typeId = int.Parse(typeId);
            int _typeId = 0;


          //  string[] impath = new string[2];
          //  string[] arr = new string[4];
            int i = 0;
            try
            {
                string imagePath, FileName;

                var AppId = Convert.ToInt32(headerValue1.FirstOrDefault());

                var objmain = dbMain.AppDetails.Where(x => x.AppId == AppId).FirstOrDefault();
                var AppDetailURL = objmain.baseImageUrl + objmain.basePath + objmain.Collection + "/";


              //  TimeSpan start = new TimeSpan(15, 0, 0);
              //  TimeSpan end = new TimeSpan(16, 0, 0);
                string hour = DateTime.Now.ToString("hh:mm tt");

                DateTime scheduledRun = DateTime.Today.AddHours(15);
                //if (AppId == 3035)
                //{
                //    _RepositoryApi.SaveAttendenceSettingsDetail(AppId, hour);

                //}
                //String timeStamp = GetTimestamp(new scheduledRun);
                //   DateTime.UtcNow - x.Timestamp == TimeSpan.FromMinutes(15)

                if (hour == "08:00 AM" && AppId == 3035)
                {
                    _RepositoryApi.SaveAttendenceSettingsDetail(AppId, hour);
                }

                foreach (var item in objRaw)
                {
                    gcDetail.userId = item.userId;
                    gcDetail.Distance = item.Distance;

                    switch (item.gcType)
                    {
                        case 1:
                            string houseid1 = item.ReferenceID;
                            string[] houseList = houseid1.Split(',');
                            gcDetail.houseId = houseList[0];
                            if(houseList.Length>1)
                            { 
                            gcDetail.wastetype = houseList[1];
                            }
                            //   gcDetail.houseId = item.ReferenceID;
                            gcDetail.gcType = item.gcType;
                            gcDetail.EmpType = item.EmpType;
                            break;
                        case 2:
                            gcDetail.gpId = item.ReferenceID;
                            gcDetail.gcType = item.gcType;
                            gcDetail.EmpType = item.EmpType;
                            break;
                        case 3:
                            gcDetail.dyId = item.ReferenceID;
                            gcDetail.gcType = item.gcType;
                            gcDetail.totalGcWeight = item.totalGcWeight;
                            gcDetail.totalDryWeight = item.totalDryWeight;
                            gcDetail.totalWetWeight = item.totalWetWeight;
                            gcDetail.EmpType = item.EmpType;
                            break;
                        case 4:
                            gcDetail.LWId = item.ReferenceID;
                            gcDetail.gcType = item.gcType;
                            gcDetail.totalGcWeight = item.totalGcWeight;
                            gcDetail.totalDryWeight = item.totalDryWeight;
                            gcDetail.totalWetWeight = item.totalWetWeight;
                            gcDetail.EmpType = item.EmpType;
                            break;
                        case 5:
                            gcDetail.SSId = item.ReferenceID;
                            gcDetail.gcType = item.gcType;
                            gcDetail.totalGcWeight = item.totalGcWeight;
                            gcDetail.totalDryWeight = item.totalDryWeight;
                            gcDetail.totalWetWeight = item.totalWetWeight;
                            gcDetail.EmpType = item.EmpType;
                            break;
                        case 6:
                            gcDetail.vqrId = item.ReferenceID;
                            gcDetail.gcType = item.gcType;
                            gcDetail.totalGcWeight = item.totalGcWeight;
                            gcDetail.totalDryWeight = item.totalDryWeight;
                            gcDetail.totalWetWeight = item.totalWetWeight;
                            gcDetail.EmpType = item.EmpType;
                            break;
                        default:
                            gcDetail.houseId = "";
                            gcDetail.gpId = "";
                            gcDetail.dyId = "";
                            break;
                    }

                    gcDetail.OfflineID = item.OfflineID;
                    gcDetail.Lat = item.Lat;  
                    gcDetail.Long = item.Long;  
                    gcDetail.note = item.note;  
                    gcDetail.garbageType = item.garbageType; 
                    gcDetail.vehicleNumber = item.vehicleNumber;  
                    gcDetail.gcDate = item.gcDate;
                    gcDetail.batteryStatus = item.batteryStatus;
                    gcDetail.Distance = item.Distance;
                    gcDetail.IsLocation = item.IsLocation;
                    gcDetail.IsOffline = item.IsOffline;
                   

                    string imageStart = "", imageEnd = "";
                    imageStart = item.gpBeforImage; 
                    imageEnd = item.gpAfterImage;
                    gcDetail.gpBeforImage = imageStart;
                    gcDetail.gpAfterImage = imageEnd;
                    
                    //string Image = "";
                    //if (impath.Length == 0 || impath[0] == null)
                    //{
                    //    gcDetail.gpBeforImage = "";
                    //    gcDetail.gpAfterImage = "";
                    //}
                    //else
                    //{
                    //    if (imageStart == "" || imageStart == string.Empty || imageStart == null)
                    //    {
                    //        gcDetail.gpBeforImage = "";
                    //        if (imageEnd != "" || imageEnd != string.Empty || imageEnd != null)

                    //        {
                    //            gcDetail.gpAfterImage = impath[0];
                    //        }
                    //    }
                    //    else
                    //    {
                    //        gcDetail.gpBeforImage = impath[0];

                    //        if (impath.Length == 0 || i <= 1)
                    //        {
                    //            gcDetail.gpAfterImage = "";
                    //        }
                    //        else
                    //        {
                    //            if (imageEnd != "" || imageEnd != string.Empty || imageEnd != null)

                    //            {
                    //                gcDetail.gpAfterImage = impath[1];
                    //            }
                    //        }
                    //    }
                    //}
                

                    CollectionSyncResult detail =  _RepositoryApi.SaveGarbageCollectionOffline(gcDetail, AppId, _typeId);

                  
                    if (detail.message == "")
                    {
                        objres.Add(new CollectionSyncResult() {
                            ID = detail.ID,
                            status = "error",
                            message = "Record not inserted",
                            messageMar = "रेकॉर्ड सबमिट केले नाही"
                           });
                    }

                    objres.Add(new CollectionSyncResult()
                    {
                        ID = detail.ID,
                        status = detail.status,
                        messageMar = detail.messageMar,
                        message = detail.message,
                        isAttendenceOff= detail.isAttendenceOff,
                        houseId=detail.houseId
                    });
                }

                return objres;

            }
            catch (Exception ex)
            {

                objres.Add(new CollectionSyncResult()
                {
                    houseId = gcDetail.houseId,
                    ID = gcDetail.OfflineID,
                    status = "error",
                    message = ex.Message,
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


        [HttpPost]
        [Route("Save/DumpyardTrip")]
        public List<CollectionDumpSyncResult> SaveDumpyardTrip(List<DumpTripVM> objRaw)
        {
            _RepositoryApi = new Repository();
            DumpTripVM gcDetail = new DumpTripVM();
            TransDumpTD objDetailDump = new TransDumpTD();
            List<CollectionDumpSyncResult> objres = new List<CollectionDumpSyncResult>();
         
            try
            {
                HttpClient client = new HttpClient();
                int ptid = 0;
                foreach (var item in objRaw)
                {
                   
                    gcDetail.transId = item.transId;
                    gcDetail.dyId = item.dyId;
                    gcDetail.startDateTime = item.startDateTime;
                    gcDetail.endDateTime = item.endDateTime;
                    gcDetail.userId = item.userId;
                    gcDetail.houseList = item.houseList;
                    gcDetail.tripNo = item.tripNo;
                    gcDetail.vehicleNumber = item.vehicleNumber;
                    gcDetail.totalDryWeight = item.totalDryWeight;
                    gcDetail.totalWetWeight = item.totalWetWeight;
                    gcDetail.totalGcWeight = item.totalGcWeight;
                    var json = JsonConvert.SerializeObject(gcDetail, Formatting.Indented);
                    var stringContent = new StringContent(json);
                    stringContent.Headers.ContentType.MediaType = "application/json";
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string[] transList = item.transId.Split('&');
                    int AppId = Convert.ToInt32(transList[0]);
                    AppDetail objmain = dbMain.AppDetails.Where(x => x.AppId == AppId).FirstOrDefault();
                    transList[2] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    gcDetail.transId = string.Join("&", transList);
                   // string strdate = string.Empty;
                   // transList[2] = DateTime.ParseExact(strdate, "yyyy-MM-dd HH:mm:ss.SSS", CultureInfo.InvariantCulture).ToString();

                    CollectionDumpSyncResult result = new CollectionDumpSyncResult();
                    using (DevSwachhBharatNagpurEntities db = new DevSwachhBharatNagpurEntities(AppId))
                    {
                        var ptripid = db.TransDumpTDs.OrderByDescending(c => c.TransBcId).FirstOrDefault().TransBcId;
                        ptid = Convert.ToInt32(ptripid) + 1;
                        var response = client.PostAsync("http://35.164.93.75/trips/"+ ptid + "/tripdata", stringContent);
                        HttpResponseMessage rs = response.Result;
                        string responseString = rs.Content.ReadAsStringAsync().Result;
                        String[] spearator = responseString.Split(',');
                        string sdsd2 = spearator[2].Remove(0, 8);
                        var bcTransId = sdsd2.Substring(0, sdsd2.Length - 2);
                        gcDetail.bcTransId = bcTransId;

                         var Getresponse = client.GetAsync("http://35.164.93.75/trips/" + ptid);

                     //   var Getresponse = client.GetAsync("http://35.164.93.75/trips/25");
                        HttpResponseMessage getrs = Getresponse.Result;
                        string getresponseString = getrs.Content.ReadAsStringAsync().Result;
                        String[] getspearator = getresponseString.Split(',');
                        string getstatus = getspearator[2].Remove(0, 37);
                        var getstatus2 = getstatus.Substring(0, getstatus.Length - 2);
                        if(getstatus2== "FAILED: ")
                        {
                            gcDetail.TStatus = false;
                        }
                        if (getstatus2 == "SUCCESS")
                        {
                            gcDetail.TStatus = true;
                        }

                    }
                       

                    CollectionDumpSyncResult detail = _RepositoryApi.SaveDumpyardTripCollection(gcDetail);

                    
                    objres.Add(new CollectionDumpSyncResult()
                    {
                        tripId=ptid,
                        transId = detail.transId,
                        status = detail.status,
                        messageMar = detail.messageMar,
                        message = detail.message,
                        dumpId = detail.dumpId,
                        bcTransId=detail.bcTransId
                    });
                }
            }
            catch (Exception ex)
            {
                objres.Add(new CollectionDumpSyncResult()
                {
                    status = "error",
                    message=ex.Message,
                    messageMar = "काहीतरी चुकीचे आहे, पुन्हा प्रयत्न करा..",

                });
                return objres;
            }
            return objres;
        }


      
    }
}
