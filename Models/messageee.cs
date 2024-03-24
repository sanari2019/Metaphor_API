using System;
using RepoDb.Attributes;


namespace Metaphor_Backend.Models
{

   
    public class Messageee
    {
        public int Id { get; set; }
        public int userId { get; set; }

        public string? message { get; set; }
    }
}