using Newtonsoft.Json;

namespace Analog_API.Api
{
    public class Employee
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        // ReSharper disable once InconsistentNaming
        [JsonProperty("tusername")]
        public string TUsername { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("realname")]
        public string Realname { get; set; }

        [JsonProperty("url")]
        public object Url { get; set; }

        [JsonProperty("jabber")]
        public object Jabber { get; set; }

        [JsonProperty("icq")]
        // ReSharper disable once InconsistentNaming
        public object ICQ { get; set; }

        [JsonProperty("msn")]
        // ReSharper disable once InconsistentNaming
        public object MSN { get; set; }

        [JsonProperty("aim")]
        // ReSharper disable once InconsistentNaming
        public object AIM { get; set; }

        [JsonProperty("yahoo")]
        public object Yahoo { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("signature")]
        public object Signature { get; set; }

        [JsonProperty("disp_topics")]
        public object DispTopics { get; set; }

        [JsonProperty("disp_posts")]
        public object DispPosts { get; set; }

        [JsonProperty("email_setting")]
        public string EmailSetting { get; set; }

        [JsonProperty("notify_with_post")]
        public string NotifyWithPost { get; set; }

        [JsonProperty("auto_notify")]
        public string AutoNotify { get; set; }

        [JsonProperty("show_smilies")]
        public string ShowSmilies { get; set; }

        [JsonProperty("show_img")]
        public string ShowImg { get; set; }

        [JsonProperty("show_img_sig")]
        public string ShowImgSig { get; set; }

        [JsonProperty("show_avatars")]
        public string ShowAvatars { get; set; }

        [JsonProperty("show_sig")]
        public string ShowSig { get; set; }

        [JsonProperty("access_keys")]
        public string AccessKeys { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("dst")]
        public string DaylightSavingTime { get; set; }

        [JsonProperty("time_format")]
        public string TimeFormat { get; set; }

        [JsonProperty("date_format")]
        public string DateFormat { get; set; }

        [JsonProperty("language")]
        public object Language { get; set; }

        [JsonProperty("style")]
        public string Style { get; set; }

        [JsonProperty("num_posts")]
        public string NumPosts { get; set; }

        [JsonProperty("last_post")]
        public object LastPost { get; set; }

        [JsonProperty("last_search")]
        public object LastSearch { get; set; }

        [JsonProperty("last_email_sent")]
        public object LastEmailSent { get; set; }

        [JsonProperty("registered")]
        public string Registered { get; set; }

        [JsonProperty("registration_ip")]
        public string RegistrationIp { get; set; }

        [JsonProperty("last_visit")]
        public string LastVisit { get; set; }

        [JsonProperty("last_active")]
        public string LastActive { get; set; }

        [JsonProperty("admin_note")]
        public object AdminNote { get; set; }

        [JsonProperty("activate_string")]
        public object ActivateString { get; set; }

        [JsonProperty("activate_key")]
        public object ActivateKey { get; set; }

        [JsonProperty("pun_bbcode_enabled")]
        public string PunBbcodeEnabled { get; set; }

        [JsonProperty("pun_bbcode_use_buttons")]
        public string PunBbcodeUseButtons { get; set; }

        [JsonProperty("pun_pm_new_messages")]
        public object PunPmNewMessages { get; set; }

        [JsonProperty("pun_pm_long_subject")]
        public string PunPmLongSubject { get; set; }

        [JsonProperty("newsletter")]
        public string Newsletter { get; set; }

        [JsonProperty("password_created_date")]
        public string PasswordCreatedDate { get; set; }

        [JsonProperty("eid")]
        public string Eid { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("deleted")]
        public string Deleted { get; set; }

        [JsonProperty("deleted_by")]
        public string DeletedBy { get; set; }

        [JsonProperty("legal_agree")]
        public string LegalAgree { get; set; }

        [JsonProperty("referral")]
        public string Referral { get; set; }

        [JsonProperty("wage")]
        public string Wage { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("nick_name")]
        public string NickName { get; set; }

        [JsonProperty("birth_day")]
        public string BirthDay { get; set; }

        [JsonProperty("birth_month")]
        public string BirthMonth { get; set; }

        [JsonProperty("smsgateway")]
        public string SmsGateway { get; set; }

        [JsonProperty("cell_phone")]
        public string CellPhone { get; set; }

        [JsonProperty("cellphone_confirmed")]
        public string CellPhoneConfirmed { get; set; }

        [JsonProperty("last_sms_sent")]
        public string LastSmsSent { get; set; }

        [JsonProperty("home_phone")]
        public string HomePhone { get; set; }

        [JsonProperty("avatar")]
        public Avatar Avatar { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("p_email")]
        public string PEmail { get; set; }

        [JsonProperty("p_phone")]
        public string PPhone { get; set; }

        [JsonProperty("notify_sms")]
        public string NotifySms { get; set; }

        [JsonProperty("notify_email")]
        public string NotifyEmail { get; set; }

        [JsonProperty("e_new_pm")]
        public string ENewPm { get; set; }

        [JsonProperty("ical")]
        public string Ical { get; set; }

        [JsonProperty("24hr")]
        public string _24hr { get; set; }

        [JsonProperty("startday")]
        public string Startday { get; set; }

        [JsonProperty("pref_caltime")]
        public string PrefCaltime { get; set; }

        [JsonProperty("pref_shift_autoconfirm")]
        public string PrefShiftAutoconfirm { get; set; }

        [JsonProperty("undertime")]
        public string Undertime { get; set; }

        [JsonProperty("overtime")]
        public string Overtime { get; set; }

        [JsonProperty("recommend")]
        public string Recommend { get; set; }

        [JsonProperty("recommendation")]
        public string Recommendation { get; set; }

        [JsonProperty("tut_v2_sched")]
        public string TutV2Sched { get; set; }

        [JsonProperty("daily_overtime")]
        public string DailyOvertime { get; set; }

        [JsonProperty("max_days_row")]
        public string MaxDaysRow { get; set; }

        [JsonProperty("pref_vacation_max_days")]
        public string PrefVacationMaxDays { get; set; }

        [JsonProperty("timezone_id")]
        public object TimezoneId { get; set; }

        [JsonProperty("monthly_undertime")]
        public string MonthlyUndertime { get; set; }

        [JsonProperty("monthly_overtime")]
        public string MonthlyOvertime { get; set; }

        [JsonProperty("pref_mtimebshifts")]
        public string PrefMtimebshifts { get; set; }

        [JsonProperty("avatar_url")]
        public object AvatarUrl { get; set; }

        [JsonProperty("deactivated")]
        public string Deactivated { get; set; }

        [JsonProperty("work_start_date")]
        public string WorkStartDate { get; set; }

        [JsonProperty("screen_logger")]
        public string ScreenLogger { get; set; }

        [JsonProperty("sc_freq")]
        public string ScFreq { get; set; }

        [JsonProperty("newsletter_receiver")]
        public string NewsletterReceiver { get; set; }

        [JsonProperty("job_title")]
        public string JobTitle { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("timezone_name")]
        public string TimezoneName { get; set; }

        [JsonProperty("group_name")]
        public string GroupName { get; set; }

        [JsonProperty("status_name")]
        public string StatusName { get; set; }

        [JsonProperty("schedules")]
        public Schedules Schedules { get; set; }
    }
}