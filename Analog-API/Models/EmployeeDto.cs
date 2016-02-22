namespace Analog_API.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string AvatarUrl { get; set; }
    }

    public class EmployeeMiniDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
    }
}