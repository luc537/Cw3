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

        public Enrollment GetEnrollment(string IndexNo)
        {
            {
                using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s15508;Integrated Security=True"))
                using (var com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = $"select Student.IndexNumber, Enrollment.IdEnrollment, Studies.IdStudy, Enrollment.Semester, Studies.Name, Enrollment.StartDate from Enrollment join Student on Student.IdEnrollment = Enrollment.IdEnrollment join Studies on Enrollment.IdStudy = Studies.IdStudy where Student.IndexNumber = '{IndexNo}';";

                    var en = new Enrollment();
                    var study = new Study();
                    con.Open();
                    var dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        en.IdEnrollment = (int)dr["IdEnrollment"];
                        en.StartDate = (DateTime)dr["StartDate"];
                        en.Semester = (int)dr["Semester"];
                        study.IdStudy = (int)dr["IdStudy"];
                        study.Name = dr["Name"].ToString();
                        en.study = study;
                    }
                    con.Close();
                    return en;
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
                com.CommandText = "select * from Student inner join Enrollment on Student.IdEnrollment = Enrollment.IdEnrollment inner join Studies on Enrollment.IdStudy = Studies.IdStudy;";
                


                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    var en = new Enrollment();
                    var study = new Study();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = (DateTime)dr["BirthDate"];
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    en.IdEnrollment = (int)dr["IdEnrollment"];
                    en.Semester= (int)dr["Semester"];
                    en.StartDate = DateTime.Now;
                    study.IdStudy = (int)dr["IdStudy"];
                    study.Name = dr["Name"].ToString();
                    if (en.Semester != 0) { //zalążki rozważań nad "aktywnym" semestrem danego studenta
                        st.CurrentSemester = en.Semester;
                        st.CurrentStudiesName = study.Name;
                    }
                    en.study = study;
                    st.StudEnrollment = en;
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
