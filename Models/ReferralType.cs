using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    [Map("[referralType]")]
     public class ReferralType
    {

        public int Id { get; set; }


        public string Type { get; set; }
    }

}