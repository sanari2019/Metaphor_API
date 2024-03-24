using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    public class SampleFilterModel
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int? sampleNo { get; set; }
        public int? ulid { get; set; }
        public int? statusId { get; set; }
    }
}
