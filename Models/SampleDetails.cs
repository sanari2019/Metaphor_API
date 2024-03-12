using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    [Map("[sampleDetail]")]
    public class SampleDetail
    {
        public int id { get; set; }
        public int sampleNo { get; set; }
        public bool sampleCollected { get; set; }
        public bool collectedBy { get; set; }
        public DateTime? collectedDate { get; set; }
        public bool sampleAcknowledged { get; set; }
        public int acknowledgedBy { get; set; }
        public DateTime? acknowledgedDate { get; set; }
        public bool sampleDispatched { get; set; }
        public int dispatchedBy { get; set; }
        public DateTime? dispatchDate { get; set; }
        public bool cancelled { get; set; }
        public int cancelledBy { get; set; }
        public string? cancellationReason { get; set; }
        public string? remarks { get; set; }
        public bool active { get; set; }
        public int encodedBy { get; set; }
    }
}
