using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace Activity.Models
{
    public class MsSqlRepository
    {
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string connectionstring = @"Data Source=localhost;Initial Catalog=Student;Persist Security Info=True;Integrated Security=true;Encrypt=false;";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = new SqlCommand("select Id,StudentNumber,LastName,FirstName,Birthday,Address from Student", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student();
                student.Address = reader.GetString(5);
                student.StudentNumber = reader.GetInt32(1);
                student.LastName = reader.GetString(2);
                student.FirstName = reader.GetString(3);
                student.Birthday = reader.GetDateTime(4);
                student.Id = reader.GetInt32(0);
                students.Add(student);
            }
            return students;
        }
        public void AddStudent(Student student)
        {
            List<Student> students = new List<Student>();
            string connectionstring = @"Data Source=CL7-PROF\SQLExpress;Initial Catalog=Student;Persist Security Info=True;Integrated Security=true;Encrypt=false;";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Student(StudentNumber,LastName,FirstName,Birthday,Address) values ('" + student.StudentNumber
                + "','" + student.LastName + "','" + student.FirstName + "','" + student.Birthday.ToString("yyyy-MM-dd")
                + "','" + student.Address + "')", connection);
            var reader = command.ExecuteScalar();

        }

        public void UpdateStudent(string studentNo, Student student)
        {
            List<Student> students = new List<Student>();
            string connectionstring = @"Data Source=localhost;Initial Catalog=Student;Persist Security Info=True;Integrated Security=true;Encrypt=false;";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = new SqlCommand("update Employee set LastName='" + student.LastName
                + "', FirstName='" + student.FirstName
                + "', Address='" + student.Address
                + "', Birthday='" + student.Birthday.ToString("yyyy-MM-dd")
                + "' where StudentNumber='" + studentNo + "'", connection);
            var reader = command.ExecuteScalar();
        }
    }
}