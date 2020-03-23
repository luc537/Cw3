using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public StudentsController(IDbService dbService)
        { _dbService = dbService; }


        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_dbService.GetStudents());
        }
        [HttpGet("{id}")]
        public IActionResult GetStudents(string id)
        {
            return Ok(_dbService.GetStudent(id));
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            //add to database
            //generate index number
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(Student student)
        {
            Student mockStudent = new Student
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                IndexNumber = "s1234"
            };
            mockStudent.FirstName = student.FirstName;
            mockStudent.LastName = student.LastName;
            mockStudent.IndexNumber = student.IndexNumber;

            return Ok($"Aktualizacja dokończona. {mockStudent}");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent()
        {

            return Ok("Usuwanie ukończone");
        }
    }
}