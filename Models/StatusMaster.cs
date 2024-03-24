using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    [Map("[statusMaster]")]
    public class StatusMaster
    {

        public int id { get; set; }

        public string statusType { get; set; }

        public string status { get; set; }

        public string statusColor { get; set; }

        public string colorName { get; set; }

        public string code { get; set; }

        public bool active { get; set; }
    }
}
