using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            //MOCK

            //_students = new List<Student> {
            //    new Student {IDStudent = 1, FirstName = "Jan", LastName = "Kowalski", IndexNumber = "s1234"},
            //    new Student {IDStudent = 2, FirstName = "Grzegorz", LastName = "Kalaska", IndexNumber = "s4321"},
            //    new Student {IDStudent = 3, FirstName = "Piotr", LastName = "Gago", IndexNumber = "pgago"}
            //};
        }

        public void BeginTran()
        {
            throw new NotImplementedException();
        }

        public bool CheckIndex(string index)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Enrollment GetEnrollment(string IndexNo)
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(string IndexNo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudents()
        {
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s15508;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select FirstName, LastName, BirthDate, Enrollment.Semester, Studies.Name from Student join Enrollment on Student.IdEnrollment = Enrollment.IdEnrollment join Studies on Enrollment.IdStudy = Studies.IdStudy;";


                var st = new Student();
                _students = new List<Student>();
                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = (DateTime)dr["BirthDate"];
                    //st.Semester = (int)dr["Semester"];
                    //st.StudiesName = dr["Name"].ToString();
                    _students.Append<Student>(st);
                }
                con.Close();
                return _students;
            }
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
