using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentViewModel.Model
{
    internal class StudentDataBase
    {

        private readonly IDbConnection dbConnection;

        public StudentDataBase(string dbconnection)
        {
            dbConnection = new SqlConnection(dbconnection);
        }


        public List<Student> SelectedStudents()
        {
            List<Student> students = dbConnection.Query<Student>("SELECT id_student, SSurName, SName, SAge FROM Student").ToList();
            return students;
        }

        public bool IsStudentExist(string surname, string name)
        {
            string sqlQuery = "SELECT COUNT(*) FROM Student WHERE SSurName = @Surname AND SName = @Name";
            int count = dbConnection.QuerySingle<int>(sqlQuery, new { Surname = surname, Name = name });
            return count > 0;
        }

        public void AddStudent(string surname, string name, int age)
        {
        
            dbConnection.Execute("INSERT INTO Student (SSurName, SName, SAge) VALUES (@Surname, @Name, @Age)",
                new { Surname = surname, Name = name, Age = age });
        }

        public void UpdateStudent(int id, string surname, string name, int age)
        {
            string sql = "UPDATE Student SET SSurName = @SurName, SName = @Name, SAge = @Age WHERE id_student = @id_student";

            dbConnection.Execute(sql, new { SurName = surname, Name = name, Age = age, id_student = id });
        }

        public void DeleteStudent(int id)
        {
            string sqlQuery = "DELETE FROM Student WHERE id_student=@id_student";
            dbConnection.Execute(sqlQuery, new { id_student = id });
        }
    }
}
