using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
using RouteAttribute = System.Web.Mvc.RouteAttribute;
using Activity.Models;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using HttpPutAttribute = System.Web.Mvc.HttpPutAttribute;

namespace Activity.Controllers
{
    [Route("api/MsSqlStudents")]
    [ApiController]
    public class MsSqlStudentController : ControllerBase
    {
        [HttpGet]
        public List<Student> Get()
        {
            var students = new MsSqlRepository().GetStudents();
            return students;
        }

        [HttpPost]
        public Student Add(Student student)
        {
            var repository = new MsSqlRepository();
            repository.AddStudent(student);
            return student;
        }

        [HttpPut]
        public Student Edit(string id, Student student)
        {
            var repository = new MsSqlRepository();
            repository.UpdateStudent(id, student);
            return student;
        }
    }
}
