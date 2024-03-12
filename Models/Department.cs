using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    [Map("[department]")]
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
