using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    [Map("[patients]")]
    public class Patient
    {
        public int id { get; set; }
        public int ulid { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string company { get; set; }
        public DateTime dob { get; set; }
        public string fullAddress { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string emergencyContactFullName { get; set; }
        public string emergencyContactPhoneNumber { get; set; }
        public string referralType { get; set; }
        public string referredBy { get; set; }
        public string bill { get; set; }
        public string result { get; set; }
        public int encodedBy { get; set; }
        public DateTime encodedDate { get; set; }
        public int lastChangedBy { get; set; }
        public DateTime lastChangedDate { get; set; }
    }
}
