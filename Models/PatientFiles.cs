using System;
using RepoDb.Attributes;

namespace Metaphor_Backend.Models
{
    [Map("[patientfiles]")]



    public class PatientFilesModel
    {
        public int Id { get; }
        public int ulid { get; set; }
        public string filePath { get; set; }
    }
}