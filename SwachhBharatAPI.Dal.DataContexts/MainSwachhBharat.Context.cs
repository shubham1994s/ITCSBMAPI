﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SwachhBharatAPI.Dal.DataContexts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DevSwachhBharatMainEntities : DbContext
    {
        public DevSwachhBharatMainEntities()
            : base("name=DevSwachhBharatMainEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AD_USER_MST_LIQUID> AD_USER_MST_LIQUID { get; set; }
        public virtual DbSet<AdminContact> AdminContacts { get; set; }
        public virtual DbSet<AEmployeeMaster> AEmployeeMasters { get; set; }
        public virtual DbSet<AppConnection> AppConnections { get; set; }
        public virtual DbSet<AppDetail> AppDetails { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BinMaster> BinMasters { get; set; }
        public virtual DbSet<country_states> country_states { get; set; }
        public virtual DbSet<EmployeeMaster> EmployeeMasters { get; set; }
        public virtual DbSet<Feedback_playstore> Feedback_playstore { get; set; }
        public virtual DbSet<Game_AnswerType> Game_AnswerType { get; set; }
        public virtual DbSet<Game_Slogan> Game_Slogan { get; set; }
        public virtual DbSet<GameDetail> GameDetails { get; set; }
        public virtual DbSet<GameMaster> GameMasters { get; set; }
        public virtual DbSet<GamePlayerDetail> GamePlayerDetails { get; set; }
        public virtual DbSet<GoogelHitDetail> GoogelHitDetails { get; set; }
        public virtual DbSet<GoogleAPIDetail> GoogleAPIDetails { get; set; }
        public virtual DbSet<HSUR_Daily_Attendance> HSUR_Daily_Attendance { get; set; }
        public virtual DbSet<LanguageInfo> LanguageInfoes { get; set; }
        public virtual DbSet<RFID_Master> RFID_Master { get; set; }
        public virtual DbSet<Sauchalay_feedback> Sauchalay_feedback { get; set; }
        public virtual DbSet<state_districts> state_districts { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<UR_Location> UR_Location { get; set; }
        public virtual DbSet<UserInApp> UserInApps { get; set; }
        public virtual DbSet<AD_USER_MST_STREET> AD_USER_MST_STREET { get; set; }
        public virtual DbSet<tehsil> tehsils { get; set; }
        public virtual DbSet<CheckAppD> CheckAppDs { get; set; }
        public virtual DbSet<HSEmpCodeDatail> HSEmpCodeDatails { get; set; }
    
        public virtual ObjectResult<Update_Trigger_Result> Update_Trigger()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Update_Trigger_Result>("Update_Trigger");
        }
    
        public virtual ObjectResult<SP_DistanceCount_Result> SP_DistanceCount(Nullable<double> sLat, Nullable<double> sLong, Nullable<double> dLat, Nullable<double> dLong)
        {
            var sLatParameter = sLat.HasValue ?
                new ObjectParameter("sLat", sLat) :
                new ObjectParameter("sLat", typeof(double));
    
            var sLongParameter = sLong.HasValue ?
                new ObjectParameter("sLong", sLong) :
                new ObjectParameter("sLong", typeof(double));
    
            var dLatParameter = dLat.HasValue ?
                new ObjectParameter("dLat", dLat) :
                new ObjectParameter("dLat", typeof(double));
    
            var dLongParameter = dLong.HasValue ?
                new ObjectParameter("dLong", dLong) :
                new ObjectParameter("dLong", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_DistanceCount_Result>("SP_DistanceCount", sLatParameter, sLongParameter, dLatParameter, dLongParameter);
        }
    
        public virtual int All_Schedule()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("All_Schedule");
        }
    
        public virtual int All_SP_GetEmpWiseHouseScan()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("All_SP_GetEmpWiseHouseScan");
        }
    
        public virtual int HouseEntryCount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HouseEntryCount");
        }
    
        public virtual int SP_Admin_table()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Admin_table");
        }
    
        public virtual int SP_Admin2(Nullable<System.DateTime> fdate)
        {
            var fdateParameter = fdate.HasValue ?
                new ObjectParameter("fdate", fdate) :
                new ObjectParameter("fdate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Admin2", fdateParameter);
        }
    
        public virtual int SP_Admin3()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Admin3");
        }
    
        public virtual int SP_Admin5()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Admin5");
        }
    
        public virtual int sp_area()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_area");
        }
    
        public virtual int SP_SSRS_GarbageCollection(Nullable<int> appId, Nullable<System.DateTime> fdate, Nullable<System.DateTime> tdate, Nullable<int> userId, Nullable<int> garbageType)
        {
            var appIdParameter = appId.HasValue ?
                new ObjectParameter("appId", appId) :
                new ObjectParameter("appId", typeof(int));
    
            var fdateParameter = fdate.HasValue ?
                new ObjectParameter("fdate", fdate) :
                new ObjectParameter("fdate", typeof(System.DateTime));
    
            var tdateParameter = tdate.HasValue ?
                new ObjectParameter("tdate", tdate) :
                new ObjectParameter("tdate", typeof(System.DateTime));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            var garbageTypeParameter = garbageType.HasValue ?
                new ObjectParameter("garbageType", garbageType) :
                new ObjectParameter("garbageType", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_SSRS_GarbageCollection", appIdParameter, fdateParameter, tdateParameter, userIdParameter, garbageTypeParameter);
        }
    
        public virtual ObjectResult<SP_ULBADMIN_Result> SP_ULBADMIN(Nullable<int> divisionIdIn, Nullable<int> districtIdIn, Nullable<int> appIdIN, Nullable<int> userId, Nullable<System.DateTime> date)
        {
            var divisionIdInParameter = divisionIdIn.HasValue ?
                new ObjectParameter("DivisionIdIn", divisionIdIn) :
                new ObjectParameter("DivisionIdIn", typeof(int));
    
            var districtIdInParameter = districtIdIn.HasValue ?
                new ObjectParameter("DistrictIdIn", districtIdIn) :
                new ObjectParameter("DistrictIdIn", typeof(int));
    
            var appIdINParameter = appIdIN.HasValue ?
                new ObjectParameter("AppIdIN", appIdIN) :
                new ObjectParameter("AppIdIN", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ULBADMIN_Result>("SP_ULBADMIN", divisionIdInParameter, districtIdInParameter, appIdINParameter, userIdParameter, dateParameter);
        }
    
        public virtual ObjectResult<SP_ULBADMINMAP_Result> SP_ULBADMINMAP(Nullable<int> divisionIdIn, Nullable<int> districtIdIn, Nullable<int> appIdIN, Nullable<int> userId)
        {
            var divisionIdInParameter = divisionIdIn.HasValue ?
                new ObjectParameter("DivisionIdIn", divisionIdIn) :
                new ObjectParameter("DivisionIdIn", typeof(int));
    
            var districtIdInParameter = districtIdIn.HasValue ?
                new ObjectParameter("DistrictIdIn", districtIdIn) :
                new ObjectParameter("DistrictIdIn", typeof(int));
    
            var appIdINParameter = appIdIN.HasValue ?
                new ObjectParameter("AppIdIN", appIdIN) :
                new ObjectParameter("AppIdIN", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ULBADMINMAP_Result>("SP_ULBADMINMAP", divisionIdInParameter, districtIdInParameter, appIdINParameter, userIdParameter);
        }
    
        public virtual ObjectResult<SP_ULBADMINSTATUS_Result> SP_ULBADMINSTATUS(Nullable<int> divisionIdIn, Nullable<int> districtIdIn, Nullable<int> appIdIN, Nullable<int> userId)
        {
            var divisionIdInParameter = divisionIdIn.HasValue ?
                new ObjectParameter("DivisionIdIn", divisionIdIn) :
                new ObjectParameter("DivisionIdIn", typeof(int));
    
            var districtIdInParameter = districtIdIn.HasValue ?
                new ObjectParameter("DistrictIdIn", districtIdIn) :
                new ObjectParameter("DistrictIdIn", typeof(int));
    
            var appIdINParameter = appIdIN.HasValue ?
                new ObjectParameter("AppIdIN", appIdIN) :
                new ObjectParameter("AppIdIN", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ULBADMINSTATUS_Result>("SP_ULBADMINSTATUS", divisionIdInParameter, districtIdInParameter, appIdINParameter, userIdParameter);
        }
    
        public virtual ObjectResult<SP_UserLatLongDetail_Result> SP_UserLatLongDetail(Nullable<int> userid, Nullable<int> typeId)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var typeIdParameter = typeId.HasValue ?
                new ObjectParameter("typeId", typeId) :
                new ObjectParameter("typeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_UserLatLongDetail_Result>("SP_UserLatLongDetail", useridParameter, typeIdParameter);
        }
    
        public virtual ObjectResult<SP_UserLatLongDetailMain_Result> SP_UserLatLongDetailMain(Nullable<int> userid, Nullable<int> typeId)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var typeIdParameter = typeId.HasValue ?
                new ObjectParameter("typeId", typeId) :
                new ObjectParameter("typeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_UserLatLongDetailMain_Result>("SP_UserLatLongDetailMain", useridParameter, typeIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DailyScanCount(string ulbappid)
        {
            var ulbappidParameter = ulbappid != null ?
                new ObjectParameter("Ulbappid", ulbappid) :
                new ObjectParameter("Ulbappid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DailyScanCount", ulbappidParameter);
        }
    
        public virtual ObjectResult<PropertyScanCount_Result> PropertyScanCount(Nullable<System.DateTime> fDate)
        {
            var fDateParameter = fDate.HasValue ?
                new ObjectParameter("fDate", fDate) :
                new ObjectParameter("fDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PropertyScanCount_Result>("PropertyScanCount", fDateParameter);
        }
    }
}
