using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cw3.Models
{
    [Serializable]
    public class Enrollment
    {
        //[JsonPropertyName("IdEnrollment")]
        public int IdEnrollment { get; set; }
        //[JsonPropertyName("Semester")]
        public int Semester { get; set; }
        //[JsonPropertyName("StartDate")]
        public DateTime StartDate { get; set; }
        //[JsonPropertyName("study")]
        public Study study { get; set; }
    }
}
