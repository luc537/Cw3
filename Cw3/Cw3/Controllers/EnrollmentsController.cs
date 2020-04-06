using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.DTOs.Requests;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            
            var st = new Student();
            st.FirstName = request.FirstName;


            var en = new Enrollment();
            return Ok(en);
        }
    }
}