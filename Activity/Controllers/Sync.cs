using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Activity.Models;
namespace Activity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sync :  ControllerBase
    {
        [HttpGet]
        public List<Student> Syncing()
        {
            var repository = new MyToMsSql();
            var students = repository.GetMySqlStudents();
            repository.SyncToMsSql(students);
            var mssqlstudents = new MsSqlRepository().GetStudents();
            return mssqlstudents;
        }
    }
}