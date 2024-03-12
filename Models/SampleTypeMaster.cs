using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    [Map("[sampleTypeMaster]")]
     public class SampleTypeMaster
    {
        public int Id { get; set; }

  
        public string Name { get; set; }


        public bool Active { get; set; }

        public int EncodedBy { get; set; }


        public DateTime EncodedDate { get; set; }
    }
}