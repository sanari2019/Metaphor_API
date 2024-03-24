using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    [Map("[histologySample]")]
    public class HistologySample
    {
        public int id { get; set; }
        public int histoNo { get; set; }
        public int serviceId { get; set; }
        public int sampleNo { get; set; }
        public int stageId { get; set; }
        public string? requisitionType { get; set; }
        public string? specimenType { get; set; }
        public string? specimenSite { get; set; }
        public bool previousBiopsy { get; set; }
        public string? sutureTag { get; set; }
        public string? clinicalDetails { get; set; }
        public string? operativeFindings { get; set; }
        public string? provisionalDiagnosis { get; set; }
        public string? investigationRequested { get; set; }
        public bool sampleGrossingPerformed { get; set; }
        public int sampleGrossingPerformedBy { get; set; }
        public DateTime? sampleGrossingPerformedDate { get; set; }
        public bool tissueProcessingPerformed { get; set; }
        public int tissueProcessingPerformedBy { get; set; }
        public DateTime? tissueProcessingPerformedDate { get; set; }
        public bool embeddingPerformed { get; set; }
        public int embeddingPerformedBy { get; set; }
        public DateTime? embeddingPerformedDate { get; set; }
        public bool microtomyPerformed { get; set; }
        public int microtomyPerformedBy { get; set; }
        public DateTime? microtomyPerformedDate { get; set; }
        public bool stainingPerformed { get; set; }
        public int stainingPerformedBy { get; set; }
        public DateTime? stainingPerformedDate { get; set; }

        public ServiceMaster? serviceMaster {get; set;}
        public SampleDetail? sampleDetail {get; set;}
        public StageMaster? stageMaster {get; set;}
        public Employee? gemployee {get; set;}
        public Employee? temployee {get; set;}
        public Employee? eemployee {get; set;}
        public Employee? memployee {get; set;}
        public Employee? semployee {get; set;}


        public int userId {get; set;}

        public SamplePerService? samplePerService {get; set;}




    }
}
