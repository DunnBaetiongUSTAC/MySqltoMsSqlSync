using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Activity.Models
{
    public class MyToMsSql
    {
        public List<Student> GetMySqlStudents()
        {
            List<Student> students = new List<Student>();
            string connectionstring = "server=localhost;port=3306;database=Student;username=root;password='';";
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

                string mssqlconnectionstring = @"Data Source=CL7-PROF\SQLExpress;Initial Catalog=ITS406;Persist Security Info=True;Integrated Security=true;Encrypt=false;";
                SqlConnection mssqlconnection = new SqlConnection(mssqlconnectionstring);
                mssqlconnection.Open();
                SqlCommand mssqlcommand = new SqlCommand("select Id,EmployeeNo,LastName,FirstName,Birthday,Address from Employee where employeeno='" +
                    student.StudentNumber + "'", mssqlconnection);
                var mssqlreader = mssqlcommand.ExecuteReader();
                if (mssqlreader.Read())
                {
                    student.ForUpdating = true;
                }
                else
                {
                    student.ForUpdating = false;
                }
                mssqlconnection.Close();
                students.Add(student);
            }
            return students;
        }





        public void SyncToMsSql(List<Student> students)
        {
            foreach (var student in students)
            {
                var repository = new MsSqlRepository();
                if (student.ForUpdating)
                {
                    repository.UpdateStudent(student.StudentNumber, student);
                }
                else
                {
                    repository.AddStudent(student);
                }

            }
        }
    }
}