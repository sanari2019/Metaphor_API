using System;

namespace Metaphor_Backend.Models // Replace YourNamespace with your actual namespace
{
    public class Employee
    {
        public int id { get; set; }
        public int laboratoryLocationId { get; set; }
        public string employeeNo { get; set; }
        public int employeeTypeId { get; set; }
        public int titleId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int age { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public int cityID { get; set; }
        public int stateId { get; set; }
        public int countryId { get; set; }
        public string pinCode { get; set; }
        public string phoneHome { get; set; }
        public string phoneWork { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public DateTime joiningDate { get; set; }
        public DateTime leavingDate { get; set; }
        public int departmentId { get; set; }
        public bool active { get; set; }
        public int encodedBy { get; set; }
        public DateTime encodedDate { get; set; }
        public int lastChangedBy { get; set; }
        public DateTime lastChangedDate { get; set; }
        public string designation { get; set; }
        public bool isAccessAllResource { get; set; }
        public int facilityId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string employeeDisplayName { get; set; }
    }
}
