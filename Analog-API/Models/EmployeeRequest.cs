using Newtonsoft.Json;

namespace Analog_API.Models
{
    public class EmployeeRequest : Request
    {
        public EmployeeRequest()
        {
            Module = "staff.employee";
        }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class EmployeeData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        //public string username { get; set; }
        //public string tusername { get; set; }
        //public string email { get; set; }
        //public object title { get; set; }
        //public string realname { get; set; }
        //public object url { get; set; }
        //public object jabber { get; set; }
        //public object icq { get; set; }
        //public object msn { get; set; }
        //public object aim { get; set; }
        //public object yahoo { get; set; }
        //public string location { get; set; }
        //public object signature { get; set; }
        //public object disp_topics { get; set; }
        //public object disp_posts { get; set; }
        //public string email_setting { get; set; }
        //public string notify_with_post { get; set; }
        //public string auto_notify { get; set; }
        //public string show_smilies { get; set; }
        //public string show_img { get; set; }
        //public string show_img_sig { get; set; }
        //public string show_avatars { get; set; }
        //public string show_sig { get; set; }
        //public string access_keys { get; set; }
        //public string timezone { get; set; }
        //public string dst { get; set; }
        //public string time_format { get; set; }
        //public string date_format { get; set; }
        //public object language { get; set; }
        //public string style { get; set; }
        //public string num_posts { get; set; }
        //public object last_post { get; set; }
        //public object last_search { get; set; }
        //public string last_email_sent { get; set; }
        //public string registered { get; set; }
        //public string registration_ip { get; set; }
        //public string last_visit { get; set; }
        //public string last_active { get; set; }
        //public object admin_note { get; set; }
        //public object activate_string { get; set; }
        //public object activate_key { get; set; }
        //public string pun_bbcode_enabled { get; set; }
        //public string pun_bbcode_use_buttons { get; set; }
        //public object pun_pm_new_messages { get; set; }
        //public string pun_pm_long_subject { get; set; }
        //public string newsletter { get; set; }
        //public object eid { get; set; }
        //public string status { get; set; }
        //public string deleted { get; set; }
        //public string deleted_by { get; set; }
        //public string legal_agree { get; set; }
        //public string referral { get; set; }
        //public string name { get; set; }
        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }
        //public string nick_name { get; set; }
        //public string birth_day { get; set; }
        //public string birth_month { get; set; }
        //public string smsgateway { get; set; }
        //public string cell_phone { get; set; }
        //public string cellphone_confirmed { get; set; }
        //public string last_sms_sent { get; set; }
        //public string home_phone { get; set; }

        [JsonProperty("avatar")]
        public Avatar Avatar { get; set; }
        //public string address { get; set; }
        //public string city { get; set; }
        //public string state { get; set; }
        //public string zip { get; set; }
        //public object notes { get; set; }
        //public string p_email { get; set; }
        //public string p_phone { get; set; }
        //public string notify_sms { get; set; }
        //public string notify_email { get; set; }
        //public string e_new_pm { get; set; }
        //public string ical { get; set; }
        //public string _24hr { get; set; }
        //public string startday { get; set; }
        //public string pref_caltime { get; set; }
        //public string pref_shift_autoconfirm { get; set; }
        //public string undertime { get; set; }
        //public string overtime { get; set; }
        //public string recommend { get; set; }
        //public string recommendation { get; set; }
        //public string tut_v2_sched { get; set; }
        //public string daily_overtime { get; set; }
        //public string max_days_row { get; set; }
        //public string pref_vacation_max_days { get; set; }
        //public object timezone_id { get; set; }
        //public string monthly_undertime { get; set; }
        //public string monthly_overtime { get; set; }
        //public string pref_mtimebshifts { get; set; }
        //public Avatar_Url avatar_url { get; set; }
        //public string deactivated { get; set; }
        //public string work_start_date { get; set; }
        //public string screen_logger { get; set; }
        //public string sc_freq { get; set; }
        //public string newsletter_receiver { get; set; }
        //public object job_title { get; set; }
        //public object middle_name { get; set; }
        //public object gender { get; set; }
        //public string group { get; set; }
        //public string timezone_name { get; set; }
        //public Timezone_Info timezone_info { get; set; }
        //public string group_name { get; set; }
        //public string status_name { get; set; }
        //public Schedules schedules { get; set; }
    }

    //public class Avatar_Url
    //{
    //    public string large { get; set; }
    //    public string small { get; set; }
    //    public string bigger { get; set; }
    //    public string full { get; set; }
    //    public string profile { get; set; }
    //    public string forum { get; set; }
    //}

    //public class Timezone_Info
    //{
    //    public string timezone_id { get; set; }
    //    public string name { get; set; }
    //    public string name_formatted { get; set; }
    //    public string offset { get; set; }
    //    public int seconds { get; set; }
    //    public int hours { get; set; }
    //    public string _default { get; set; }
    //    public int minutes { get; set; }
    //}
}