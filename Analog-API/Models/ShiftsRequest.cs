using System;
using Newtonsoft.Json;

namespace Analog_API.Models
{
    public class ShiftsRequest : Request
    {
        public const string
            OverviewMode = "overview",
            LocationMode = "location",
            ScheduleMode = "schedule",
            IncompleteMode = "incomplete",
            EmployeesMode = "employees",
            EmployeeMode = "employee",
            OpenMode = "open",
            OpenApprovalMode = "openapproval",
            ConfirmMode = "confirm",
            OnNowMode = "onnow",
            LateMode = "late",
            UpcomingMode = "upcoming",
            RecentMode = "recent";

        public ShiftsRequest()
        {
            Module = "schedule.shifts";
        }

        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }
    }

    public class ShiftsData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        //public string created { get; set; }
        //public string published { get; set; }
        //public string edited { get; set; }
        //public string deleted { get; set; }
        //public string schedule { get; set; }
        //public string type { get; set; }
        //public string needed { get; set; }
        //public string working { get; set; }
        //public string user { get; set; }
        //public Date start_date { get; set; }
        //public Date end_date { get; set; }
        //public float length { get; set; }
        //public string title { get; set; }
        //public string location { get; set; }
        //public string notes { get; set; }
        //public string confirmed { get; set; }
        //public string _ref { get; set; }
        [JsonProperty("start_timestamp")]
        public string StartTimestamp { get; set; }

        [JsonProperty("end_timestamp")]
        public string EndTimestamp { get; set; }

        //public string traded { get; set; }
        //public object confirmed_start_timestamp { get; set; }
        //public object confirmed_end_timestamp { get; set; }
        //public string absent { get; set; }
        //public string perms { get; set; }
        //public string schedule_name { get; set; }
        //public string schedule_color { get; set; }
        //public string schedule_location_id { get; set; }
        //public Cost cost { get; set; }
        //public TimeObj start_time { get; set; }
        //public TimeObj end_time { get; set; }
        //public float paidtime { get; set; }
        [JsonProperty("employees")]
        public ShiftsEmployee[] Employees { get; set; }
        //public object trades { get; set; }
    }

    //public class Date
    //{
    //    public int id { get; set; }
    //    public int month { get; set; }
    //    public int day { get; set; }
    //    public int wday { get; set; }
    //    public int year { get; set; }
    //    public string weekday { get; set; }
    //    public string mname { get; set; }
    //    public int week { get; set; }
    //    public int dayid { get; set; }
    //    public int timeid { get; set; }
    //    public int timeid_exact { get; set; }
    //    public string formatted { get; set; }
    //    public string time { get; set; }
    //    public int timestamp { get; set; }
    //    public int hours { get; set; }
    //    public int minutes { get; set; }
    //    public int seconds { get; set; }
    //    public string date { get; set; }
    //    public string day_of_year { get; set; }
    //    public int week_adjusted { get; set; }
    //    public int sp_wday { get; set; }
    //}

    public class Cost
    {
        [JsonProperty("staff")]
        public int Staff { get; set; }

        [JsonProperty("hours")]
        public float Hours { get; set; }

        [JsonProperty("dollars")]
        public int Dollars { get; set; }
    }

    public class TimeObj
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }

    public class ShiftsEmployee
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        //public string avatar { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        //public string status { get; set; }
        //public string wage { get; set; }
        //public string notified_day { get; set; }
        //public string notified_hour { get; set; }
        //public string last_active { get; set; }
        //public string rate { get; set; }
        //public string ratecard { get; set; }
        //public string absent { get; set; }
        //public int cost { get; set; }
        //public object confirmed_start { get; set; }
        //public object confirmed_end { get; set; }
    }
}