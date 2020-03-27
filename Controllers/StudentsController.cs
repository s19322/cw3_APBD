using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zajecia3.Models;

namespace zajecia3.Controllers
{

    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
<<<<<<< HEAD
        private const string sqlConString = "Data Source=db-mssql;Initial Catalog=s19322;Integrated Security=True";
=======
        [HttpGet]
        public string GetStudents(string orderBy)//metoda przekazujaca dane QueryString
        {
            return $"Natalia, Hania, Maciek{ orderBy }";
        }
>>>>>>> fcb6875c4f420e816fc8821495d5fce4710f1564


        [HttpGet]
        public IActionResult GetStudent() {
            {
<<<<<<< HEAD
                List<Student> students = new List<Student>();
                var con = new SqlConnection(sqlConString) ;

                    using (var comand = new SqlCommand()) { 

=======
                return Ok("Malewski");
            }
            return NotFound("Nie znaleziono studenta");
        }
>>>>>>> fcb6875c4f420e816fc8821495d5fce4710f1564

                    comand.Connection = con;
                    comand.CommandText = " select s.FirstName,s.LastName,s.BirthDate,stud.Name.e,e.Semester " +
                                        "from student s inner join Enrollment e on s.IdEnrollment = e.IdEnrollment " +
                                        "inner join studies stud on e.IdStudy = stud.IdStudy; ";
                    con.Open();

                    var r = comand.ExecuteReader();//???blad z executereader
                    while (r.Read())
                    {
                        var st = new Student();
                        st.FirstName =r["FirstName"].ToString();
                        students.Add(st);
                    }
                    con.Dispose();
                    foreach (Student s in students)
                        return Ok(s);
                }
                return Ok();
            }
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
            if(id==10)
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
