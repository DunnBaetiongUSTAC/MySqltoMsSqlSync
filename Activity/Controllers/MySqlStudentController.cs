using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Activity.Models;
namespace Activity.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class MySqlStudentController : ControllerBase
    {

        [HttpGet]
        public List<Student> Get()
        {
            var students = new MySqlRepository().GetStudents();
            return students;
        }
        
        [HttpGet]
        [Route("{id}")]
        public Student Get(int id)
        {
            var student = new MySqlRepository().GetStudent(id);
            return student;
        }

        [HttpPost]
        public Student Add(Student student)
        {
            var repository = new MySqlRepository();
            repository.AddStudent(student);
            return student;
        }
    }
}