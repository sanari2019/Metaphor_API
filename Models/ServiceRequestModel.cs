using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    public class ServiceRequestModel
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int? sampleNo { get; set; }
        public int? sampleUlid { get; set; }
        public int? sampleStatusId { get; set; }
        public int? stageId { get; set; }
        public int? sampleServiceId { get; set; }
        public int? sampleHistoNo { get; set; }
    }

}
