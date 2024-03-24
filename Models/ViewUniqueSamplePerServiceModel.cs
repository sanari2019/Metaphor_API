using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    [Map("[viewUniqueSamplePerService]")]
    public class ViewUniqueSamplePerService
    {
       public int ulid { get; set; }
        public int sampleNo { get; set; }
        public int sampleTypeId { get; set; }
        public string sampleType { get; set; }
        public int statusId { get; set; }
        public string status { get; set; }
        public string statusColor { get; set; }
        public string colorName { get; set; }
        public int serviceCount { get; set; }
        public DateTime encodedDate { get; set; }
        public int referralTypeId { get; set; }
        public string referredBy { get; set; }
        public int age { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
    }
}
