using Cw3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.DAL
{
    public class StudentDbService : IDbService

    {
        private static ICollection<Student> _students;

        public StudentDbService() {
            _students = new List<Student>();
        }
        public Student GetStudent(string IndexNo)
        {
            {
                using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s15508;Integrated Security=True"))
                using (var com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = $"select IndexNumber, FirstName, LastName, BirthDate, Enrollment.Semester, Studies.Name from Student join Enrollment on Student.IdEnrollment = Enrollment.IdEnrollment join Studies on Enrollment.IdStudy = Studies.IdStudy where Student.IndexNumber = '{IndexNo}';";

                    var st = new Student();
                    con.Open();
                    var dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        st.IndexNumber = dr["IndexNumber"].ToString();
                        st.FirstName = dr["FirstName"].ToString();
                        st.LastName = dr["LastName"].ToString();
                        st.BirthDate = (DateTime)dr["BirthDate"];
                        st.Semester = (int)dr["Semester"];
                        st.StudiesName = dr["Name"].ToString();
                        
                    }
                    con.Close();
                    return st;
                }
            }
        }

        IEnumerable<Student> IDbService.GetStudents()
        {
            _students = new List<Student>();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s15508;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select IndexNumber, FirstName, LastName, BirthDate, Enrollment.Semester, Studies.Name from Student join Enrollment on Student.IdEnrollment = Enrollment.IdEnrollment join Studies on Enrollment.IdStudy = Studies.IdStudy;";

                
                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = (DateTime)dr["BirthDate"];
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.Semester = (int)dr["Semester"];
                    st.StudiesName = dr["Name"].ToString();
                    if (st == null) {
                        throw new Exception("Null Student");
                    }
                    _students.Add(st);
                }
                if (_students.Count() == 0)
                {
                    throw new Exception("Students Empty");
                }
                con.Close();
                return _students;
            }
        }
    }
}
