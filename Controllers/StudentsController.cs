using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using zajecia3.Models;

namespace zajecia3.Controllers
{

    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        private const string sqlConString = "Data Source=db-mssql;Initial Catalog=s19322;Integrated Security=True";

        [HttpGet]
        public IActionResult GetStudent()
        {

            List<Student> students = new List<Student>();
            using (SqlConnection con = new SqlConnection(sqlConString))//automatycznie wywolywane dispose()
            using (SqlCommand comand = new SqlCommand())
            {

                //  return NotFound("Nie znaleziono studenta");
                comand.Connection = con;
                comand.CommandText = "select s.FirstName,s.LastName,s.BirthDate,stud.Name,e.Semester from Student s inner join Enrollment e on s.IdEnrollment = e.IdEnrollment inner join studies stud on e.IdStudy = stud.IdStudy";
                con.Open();
                SqlDataReader r = comand.ExecuteReader();
                while (r.Read())
                {
                    var st = new Student();
                    st.Name = r["Name"].ToString();
                    st.FirstName = r["FirstName"].ToString();
                    st.Lastname = r["LastName"].ToString();
                    st.BirthDate = r["BirthDate"].ToString();
                    st.Semester = r["Semester"].ToString();
                    students.Add(st);
                }

            }
            return Ok(students);
        }

        [HttpGet("{IndexNumber}")]
        public IActionResult GetStudent(string IndexNumber)
        {
            using (SqlConnection con = new SqlConnection(sqlConString))//automatycznie wywolywane dispose()
            using (SqlCommand comand = new SqlCommand())
            {

                //  return NotFound("Nie znaleziono studenta");
                comand.Connection = con;
                comand.CommandText = "select s.FirstName,s.LastName,s.BirthDate,stud.Name,e.Semester " +
                    "from Student s inner join Enrollment e on s.IdEnrollment = e.IdEnrollment inner join studies stud on e.IdStudy = stud.IdStudy " +
                    "where IndexNumber=@indexStud";
                //zabezpieczenie przed sqlInjection
                comand.Parameters.AddWithValue("indexStud", IndexNumber);//nazwa parametru i zmienna. Tworzy od razu obiekt Parameter i dodaje do kolekcji 

                con.Open();
                
                var dr = comand.ExecuteReader();
                if (dr.Read())//jesli mam jakis zwrocony rekord
                {
                    var st = new Student();
                    st.Name = dr["Name"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.Lastname = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.Semester = dr["Semester"].ToString();
                    return Ok(st);
                }
                
            }

            return NotFound();
            }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            // student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("id")]

        public IActionResult UpdateStudent(int id)
        {
            if (id == 10)
                return Ok("aktualizacja dokonczona");

            return Ok("brak akcji");
        }
        [HttpDelete("id")]
        public IActionResult DeleteStudent(int id)
        {
            if (id == 10)
            {
                return Ok("Usuwanie ukonczone");
            }
            return Ok("brak akcji");
        }

    }
}