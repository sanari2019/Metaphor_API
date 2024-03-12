namespace Metaphor_Backend.Models
{
    public class UserCredentials
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string? Username { get; set; }
        public required string Password { get; set; }
        public int EmployeeTypeId { get; set; }
        public bool Active { get; set; }


    }
}