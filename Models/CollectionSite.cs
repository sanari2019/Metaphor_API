using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    [Map("[collectionSite]")]
    public class CollectionSite
    {

        public int Id { get; set; }


        public string Site { get; set; }


        public bool active { get; set; }
    }
}
