using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.Models;

namespace Cw3.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student> {
                new Student {IDStudent = 1, FirstName = "Jan", LastName = "Kowalski", IndexNumber = "s1234"},
                new Student {IDStudent = 2, FirstName = "Grzegorz", LastName = "Kalaska", IndexNumber = "s4321"},
                new Student {IDStudent = 3, FirstName = "Piotr", LastName = "Gago", IndexNumber = "pgago"}
            };
        }
        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
