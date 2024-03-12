using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    [Map("[samplePerService]")]
    public class SamplePerService
    {
        public int id { get; set; }
        public int sampleTypeid { get; set; }
        public int sampleNo { get; set; }
        public int serviceId { get; set; }
        public int departmentId { get; set; }
        public int collectionSiteId { get; set; }
        public int? referalTypeId { get; set; }
        public string referredBy { get; set; }
        public string remarks { get; set; }
        public int? labTechnician { get; set; }
        public int? labSupervisor { get; set; }
        public int? labDoctor { get; set; }
        public int? statusId { get; set; }
        public int? histoNo { get; set; }
        public int encodedBy { get; set; }
        public DateTime encodedDate { get; set; }
        public int? lastChangedBy { get; set; }
        public DateTime? lastChangeDate { get; set; }
        public int patientId { get; set; }
        public int ulid { get; set; }
        public string clinicalRemarks { get; set; }
        public DateTime provisionalResultDate { get; set; }
        public int? provisionalResultReleasedBy { get; set; }
        public int? reportTypeId { get; set; }
        public string finalRemarks { get; set; }
        public bool printStatus { get; set; }
        public bool printlabelSatus { get; set; }
        public DateTime testDateTime { get; set; }
        public bool? redoDiagSampleId { get; set; }
        public bool isRedone { get; set; }
        public string? location { get; set; }
        public int employeeTypePhase { get; set; }
        

        public List<int> serviceMaster { get; set; }
    }
}
