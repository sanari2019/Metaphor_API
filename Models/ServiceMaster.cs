using System;
using RepoDb.Attributes;


namespace Metaphor_Backend.Models
{
    [Map("[serviceMaster]")]
    public class ServiceMaster
    {

        public int id { get; set; }


        public int departmentId { get; set; }

        public string serviceName { get; set; }

        public bool active { get; set; }
    }
}
