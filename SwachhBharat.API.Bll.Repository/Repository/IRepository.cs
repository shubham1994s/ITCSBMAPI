﻿using SwachhBharatAPI.Dal.DataContexts;
using SwachhBhart.API.Bll.ViewModels;
using SwachhBhart.API.Bll.ViewModels.Citizen;
using SwachhBhart.API.Bll.ViewModels.CMSB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SwachhBhart.API.Bll.ViewModels.LinkULRModel;

namespace SwachhBharat.API.Bll.Repository.Repository
{
    public interface IRepository
    {
        SBUser CheckUserLogin(string email, string password, string imi, int appId, string EmpType);

        SBAdmin CheckAdminLogin(string userName, string password);
        SBUserView GetUser(int appId, int userId, int typeId);
        List<SBVehicleType> GetVehicle(int appId);
        //List<SyncResult> SaveUserLocation(List<SBUserLocation> obj, int AppId, string batteryStatus);
        List<SyncResult> SaveUserLocation(List<SBUserLocation> obj, int AppId, string batteryStatus, int typeId, string EmpType);
        //List<SyncResult> SaveUserAttendence(List<SBUserAttendence> obj, int AppId,int type, string batteryStatus);
        Result SaveUserAttendence(SBUserAttendence obj, int AppId, int type, string batteryStatus);
        List<SyncResult1> SaveUserAttendenceOffline(List<SBUserAttendence> obj, int AppId, string cdate, string EmpType);

        List<SBAAttendenceSettingsGridRow> SaveAttendenceSettingsDetail(int AppId, string hour);
        List<SBUserAttendenceView> GetUserAttendence(DateTime fdate, int appId, int userId);
        CollectionAppAreaLatLong GetAppAreaLatLong(int appId);
        
        SyncResult2 GetUserMobileIdentification(int appId, int userId, bool isSync, int batteryStatus, string imeinos);

        List<SBWorkDetails> GetUserWork(int userid, int year, int month, int appId, string EmpType);
        List<LatLongD> GetLatLong(int appId,int userid, DateTime date);
        List<SBWorkDetailsHistory> GetUserWorkDetails(DateTime date, int appId, int userId, int languageId);

        CollectionResult SaveGarbageCollection(SBGarbageCollectionView obj, int AppId, int type, string batteryStatus);
        CollectionSyncResult SaveGarbageCollectionOffline(SBGarbageCollectionView obj, int AppId, int type);
        List<SBGarbageCollectionView> GetGarbageCollection(DateTime fdate, int appId);

        CollectionDumpSyncResult SaveDumpyardTripCollection(DumpTripVM obj);
        Result GetVersionUpdate(string version, int AppId);
        Result GetAdminVersionUpdate(string version, int AppId);
        Result GetGameVersionUpdate(string version);
        List<SBArea> GetArea(int appId);

        List<CMSBZoneVM> GetZone(int appId, string SearchString);

        List<CMSBWardVM> GetWard(int AppId, string SearchString);

        List<SBAUserlocation> GetUserLocation(int appId);
        List<SBArea> GetCollectionArea(int appId, int type, string EmpType);
        List<HouseDetailsVM> GetAreaHouse(int appId, int type, string EmpType);

        List<HouseDetailsVM> GetHouseList(int appId,string EmpType);

        List<HSHouseDetailsGrid> GetHDSLList(int appId, string EmpType,string ReferanceId);

        
        List<GarbagePointDetailsVM> GetAreaPoint(int appId, int type);

        // Added Byu Saurabh (26 Apr 2019)
        List<DumpYardPointDetailsVM> GetDumpYardArea(int appId, int type);
        Result SendSMSToHOuse(int area, int AppId);

        Result CheckAttendence(int userId, int AppId, int typeId);

        // Added By Saurabh (CMS)
        SBDashboardVM GetDashboard(int appId);

        List<EmployeeVM> GetActiveEmployee(int appId);

        List<AttendanceGridVM> GetAdminAttendence(int appId, DateTime fdate, DateTime tdate, int UserId, int Offset, int Fetch_Next, string SearchString);

        List<CMSBEmployee> GetEmployee(int AppId);

        List<AHouseGarbageCollectionVM> GetHouseGarbageCollectionData(int appId, int empId, DateTime fdate, DateTime tdate, int gcType, int Offset, int Fetch_Next, string SearchString);

        //Added By Saurabh (26 Apr 2019)


        CollectionResult SaveDumpYardCollection(SBGarbageCollectionView obj, int AppId, int type, string batteryStatus);

        List<CMSBPointGarbageCollectionVM> GetPointGarbageCollectionData(int appId, int empId, DateTime fdate, DateTime tdate, int gcType, int Offset, int Fetch_Next, string SearchString);
        //Added By Nishikant (03 May 2019)

        List<CMSBGrabageCollectionVM> GetDumpYardCollectionData(int appId, int empId, DateTime fdate, DateTime tdate, int gcType, int Offset, int Fetch_Next, string SearchString);
        //Added By Nishikant (11 May 2019)

        List<CMSBLocationVM> GetLocationData(int appId, int empId, DateTime fdate, DateTime tdate, int Offset, int Fetch_Next, string SearchString);
        //Added By Nishikant (04 May 2019)

        List<CMSBUserLocationMapVM> GetUserWiseLocation(int appId, int empId, string date, int _Type);
        //Added By Nishikant (04 May 2019)

        List<CMSBHouseDetailsVM> GetHouseDetailsData(int appId, int Offset, int Fetch_Next, string SearchString);

        //Added By Nishikant (06 May 2019)

        List<CMSBGarbagePointDetailsVM> GetGarbagePointData(string SearchString, int appId, int Offset, int Fetch_Next);
        //Added By Nishikant (14 May 2019)

        List<CMSBDumpYardDetailsVM> GetDumpYardData(string SearchString, int appId, int Offset, int Fetch_Next);
        //Added By Nishikant (15 May 2019)

        List<CMSBEmployeeDetailsVM> GetEmployeeDetailsData(string SearchString, int appId, int Offset, int Fetch_Next);
        //Added By Nishikant (15 May 2019)

        Result SaveHouse(CMSBHouseDetailsVM data, int _AppId, int _HouseId);
        //Added By Nishikant (10 May 2019)

        Result SaveGarbagePoint(CMSBGarbagePointDetailsVM data, int _AppId, int _gpId);
        //Added By Nishikant (15 May 2019)

        //SaveDumpYard
        Result SaveDumpYard(CMSBDumpYardDetailsVM data, int _AppId, int _dyId);
        //Added By Nishikant (15 May 2019)

        Result SaveEmployee(CMSBEmployeeDetailsVM data, int _AppId, int UserId);
        //Added By Nishikant (16 May 2019)

        List<CMSBStatesVM> GetStates(int AppId, string SearchString);

        List<CMSBDistrictVM> GetDistrict(int AppId, string SearchString);

        List<CMSBTalukaVM> GetTaluka(int AppId, string SearchString);

        List<SBVehicleType> GetVehicleTypeList(int appId, string SearchString);
        List<CMSBAreaVM> GetAreaList(int appId, string SearchString);

        List<CMSBWardZoneVM> GetWardZoneList(int appId);
        List<SyncResult> CheckHSUserName(int appId, string username);
        List<SyncResult> CheckHSUserLoginId(int appId, string loginid);

        //Added Added By Nishikant (17 May 2019)
        Result SaveState(CMSBStatesVM state);


        //Added Added By Nishikant (17 May 2019)
        Result SaveZone(CMSBZoneVM state, int AppId);

        // Added By Saurabh (16 May 2019)
        //BigVQrEmployeeVM CheckQrEmployeeLogin(string userName, string password);

        //Added Added By Saurabh (16 May 2019)
        Result SaveQrEmployeeAttendence(BigVQREmployeeAttendenceVM obj, int AppId, int type);
        Result SaveSupervisorAttendence(BigVQREmployeeAttendenceVM obj, int type);

        Result CheckSupervisorAttendence(BigVQREmployeeAttendenceVM obj);

        List<SyncResult1> SaveQrEmployeeAttendenceOffline(List<BigVQREmployeeAttendenceVM> obj, int AppId);

        Result SaveWard(CMSBWardVM Ward, int AppId);

        Result SaveArea(CMSBAreaVM Area, int AppId);

        Result SaveVehicleType(SBVehicleType VehicleType, int AppId);
        List<CMSBUserLocationMapVM> GetUserAttenRoute(int AppId, int daId);
        //Added By Nishikant (25 May 2019)

        //added by neha
        Result SaveQrHPDCollections(BigVQRHPDVM obj, int AppId, string referanceid, int Gctype);

        List<CollectionSyncResult> SaveQrHPDCollectionsOffline(List<BigVQRHPDVM> obj, int AppId);

        //Added By Neha
        List<SBWorkDetails> GetQrWorkHistory(int userid, int year, int month, int appId);

        List<SBSurveyWork> GetSurveyWorkHistory(int userid, int year, int month, int appId);


        //Added by neha
        List<BigVQrworkhistorydetails> GetQrWorkHistoryDetails(DateTime date, int AppId, int userId);
        List<SBSurveyWorkDetails> GetSurveyWorkHistoryDetails(DateTime? date, int AppId, int userId);


        //Added By neha
        List<CMSBEmplyeeIdelGrid> GetEmployeeIdelTime(int appId, DateTime fdate, DateTime tdate, int UserId, int Offset, int Fetch_Next, string SearchString);

        //Added By neha
        List<CMSBEmpolyeeSummaryGrid> GetEmployeeSummary(int appId, DateTime fdate, DateTime tdate, int? UserId, int Offset, int Fetch_Next, string SearchString);


        //Added By neha
        Result SaveDustBinDetails(string DeviceId, string lat, string Long, string Distance, string Temp, string S1, string S2);

        //Added By neha 11june
        List<CMSBHouseLocationOnMap> GetHouseLocationOnMap(int AppId, DateTime _gcDate, int _UserId, int _areaId, int WardNo);

        BigVQRHPDVM2 GetScanifyHouseDetailsData(int appId, string ReferenceId, int gcType);

        #region Citizen
        CitizenMobileDetails GetMobileDetails(int AppId, string ReferanceId, string FCMID);

        CitizenMobileOTP GetSendOTP(int AppId, string ReferanceId, string _Mobile);

        //List<CitizenQuestionMaster> GetQuestions(int AppId);

        //Result GetAnswerDetails(string Json,int AppId, int UserID);

        GPHousedetailsVM GetGPHouseDetails(int AppId, string ReferanceId);
        Result1 SaveDeviceDetails(int appId, string ReferanceId, string FCMID, string DeviceID, string Mobile);
        Result1 SaveDeviceDetailsClear(int appId, string DeviceID, string _ReferenceID);
        #endregion
        List<CMSBUserLocationMapVM> GetHouseAttenRoute(int _AppId, int daId);
        List<CitizenCTPTAddress> GetCTPTAddress(int AppId);

        // House Scanify API Code
        SBUser CheckSupervisorUserLogin(string email, string password, string EmpType);
        List<NameULB> GetUlb(int userid, string EmpType, string Status);

        HSDashboard GetSelectedUlbData(int userid, string EmpType, int appId);

        List<HSEmployee> GetQREmployeeList(int userid, string EmpType, int appId);

        List<HouseScanifyEmployeeDetails> GetQREmployeeDetailsList(int userid, string EmpType, int appId,int QrEmpID, bool val);

       
        IEnumerable<HouseScanifyDetailsGridRow> GetHouseScanifyDetails(int qrEmpId, DateTime FromDate, DateTime Todate, int appId);

        IEnumerable<HSAttendanceGrid> GetAttendanceDetails(int userid, DateTime FromDate, DateTime Todate, int appId);

        IEnumerable<HSHouseDetailsGrid> GetHouseDetails(int userid, DateTime FromDate, DateTime Todate, int appId,string ReferanceId);

        IEnumerable<HSDumpYardDetailsGrid> GetDumpYardDetails(int userid, DateTime FromDate, DateTime Todate, int appId);

        IEnumerable<HSLiquidDetailsGrid> GetLiquidDetails(int userid, DateTime FromDate, DateTime Todate, int appId);

        IEnumerable<HSStreetDetailsGrid> GetStreetDetails(int userid, DateTime FromDate, DateTime Todate, int appId);

        IEnumerable<HSRejectCount> GetRejectedHSCount(int appId);
        IEnumerable<HSHouseDetailsGrid> GetRejectedHouseDetails(int appId);
        IEnumerable<HSLiquidDetailsGrid> GetRejectedLiquidDetails(int appId);
        IEnumerable<HSStreetDetailsGrid> GetRejectedStreetDetails(int appId);
        IEnumerable<HSDumpYardDetailsGrid> GetRejectedDumpYardDetails(int appId);

        List<UserRoleDetails> UserRoleList(int userid, string EmpType, bool val,int EmpId);

        CollectionSyncResult SaveAddEmployee(HouseScanifyEmployeeDetails obj, int AppId);

        CollectionSyncResult SaveAddEmployeePartner(EmployeePartner obj, int AppId);

        CollectionQRStatusResult UpdateQRstatus(HSHouseDetailsGrid obj, int AppId);

        CollectionSyncResult SaveAddUserRole(UserRoleDetails obj);

        List<VehicleList> GetVehicleList(int appId, int VehicleTypeId);

        List<Complaint> GetComplaintList(int appId);

        CollectionSyncResult SaveAddUpdateComplaintArise(EmpComplaintArise obj,int AppId,int Userid,bool type);

        IEnumerable<UREmployeeAttendence> UserRoleAttendance(int userid, DateTime FromDate, DateTime Todate, bool type);

        CollectionSyncResult SaveSurveyDetails(SurveyFormDetails obj, int AppId);

        List<SurveyFormDetail> GetSurveyDetailsById(int appId ,string ReferanceId);
        List<PropertyScanModel>GetTotalPropertyCount(int hsuserid, string hsType,DateTime fDate);

        List<EmployeePartner> GetEmployeePartnerList(int appid, int pId, int qrEmpId, bool status);

        List<LinkRoot> GetLinkURL(int appid);


        #region RFID
        Result SaveRfidDetails(string ReaderId, string TagId, string Lat, string Long, string Type, string DT);
        CheckHSURUsernameResponse GetHSURUsername(string loginid);
        #endregion
    }
}
