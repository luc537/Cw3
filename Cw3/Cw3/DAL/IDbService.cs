using Cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.DAL
{
    public interface IDbService
    {
        //StudentsController
        IEnumerable<Student> GetStudents();
        Enrollment GetEnrollment(string IndexNo);

        //Enrollment

        void BeginTran();
        void Rollback();
        void Commit();

        //Middleware
        public bool CheckIndex(string index);
    }
}
