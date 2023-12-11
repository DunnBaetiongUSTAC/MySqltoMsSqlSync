using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Activity.Models
{
    public class MySqlRepository
    {
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string connectionstring = "server=localhost;port=3306;database=its406;username=root;password='';";
            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select Id,StudentNumber,LastName,FirstName,Birthday,Address from Student", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student();
                student.Address = reader.GetString("Address");
                student.StudentNumber = reader.GetInt32("StudentNumber");
                student.LastName = reader.GetString("LastName");
                student.FirstName = reader.GetString("FirstName");
                student.Birthday = reader.GetDateTime("Birthday");
                student.Id = reader.GetInt32("Id");
                students.Add(student);
            }
            return students;
        }

        public Student GetStudent(int id)
        {
            Student student = new Student();
            string connectionstring = "server=localhost;port=3306;database=Student;username=root;password='';";
            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select Id,StudentNumber,LastName,FirstName,Birthday,Address from Student where id=" + id.ToString(), connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                student.Address = reader.GetString("Address");
                student.StudentNumber = reader.GetInt32("StudentNumber");
                student.LastName = reader.GetString("LastName");
                student.FirstName = reader.GetString("FirstName");
                student.Birthday = reader.GetDateTime("Birthday");
                student.Id = reader.GetInt32("Id");
            }
            return student;
        }


        public void AddStudent(Student student)
        {
            List<Student> students = new List<Student>();
            string connectionstring = "server=localhost;port=3306;database=Student;username=root;password='';";
            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();
            MySqlCommand command = new MySqlCommand("insert into Student(StudentNumber,LastName,FirstName,Birthday,Address) values ('" + student.StudentNumber
                + "','" + student.LastName + "','" + student.FirstName + "','" + student.Birthday
                + "','" + student.Address + "')", connection);
            var reader = command.ExecuteScalar();

        }
    }
}