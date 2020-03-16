using System;
using System.Collections.Generic;
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
        public IActionResult GetStudents(string orderby)
        {
            return Ok(_dbService.GetStudents());
        }
        [HttpGet("{id}")]
        public IActionResult GetStudents(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }else if (id == 2)
            {
                return Ok("Nowak");
            }
            return NotFound("Nie znaleziono studenta");
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
                IDStudent = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                IndexNumber = "s1234"
            };
            mockStudent.IDStudent = student.IDStudent;
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