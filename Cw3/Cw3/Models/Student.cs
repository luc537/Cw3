using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Cw3.Models
{
    [Serializable]
    public class Student
    {
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("IndexNumber")]
        public string IndexNumber { get; set; }
        [JsonProperty("BirthDate")]
        public DateTime BirthDate { get; set; }
        [JsonPropertyName("CurrentSemester")]
        public int CurrentSemester { get; set; }
        [JsonPropertyName("CurrentStudiesName")]
        public string CurrentStudiesName { get; set; }
        [JsonPropertyName("StudEnrollment")]
        public Enrollment StudEnrollment { get; set; }


        override
        public string ToString()
        { return $"ID:{IndexNumber}, First Name: {FirstName}, Last Name: {LastName}, Index Number: {IndexNumber}.";}
    }
}
