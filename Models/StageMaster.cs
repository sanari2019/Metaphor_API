using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    [Map("[stageMaster]")]
    public class StageMaster
    {
        public int id { get; set; }
        public string? stageType { get; set; }
        public string? stage { get; set; }
        public int sequence { get; set; }
        public bool active { get; set; }


    }
}
