using System;
using RepoDb.Attributes;


namespace Metaphor_Backend.Models
{

    [Map("[employee_types]")]
    public class EmployeeType
    {
        public int Id { get; set; }
        public string? type_Name { get; set; }
        public int Approval_Level { get; set; }
    }
}