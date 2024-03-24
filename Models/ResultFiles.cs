using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    [Map("[resultFiles]")]



    public class ResultFiles
    {
        public int id { get; set; } // Primary key, auto-incremented
        public int ulid { get; set; }
        public int sampleId { get; set; }
        public int resultStatusId { get; set; }
        public string filePath { get; set; } // Assuming nvarchar(50) corresponds to string in C#
        public bool active { get; set; }
    }
}