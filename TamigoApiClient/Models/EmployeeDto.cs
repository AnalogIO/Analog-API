namespace TamigoApiClient.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string AvatarUrl { get; set; }
    }

    public class EmployeeMiniDto
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
    }
}