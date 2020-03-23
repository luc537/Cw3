using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Models
{
    public class Student
    {
        public int IDStudent { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }

        override
        public string ToString()
        { return $"ID:{IDStudent}, First Name: {FirstName}, Last Name: {LastName}, Index Number: {IndexNumber}.";}
    }
}
