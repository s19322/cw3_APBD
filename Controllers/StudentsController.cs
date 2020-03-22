using System;
using System.Collections.Generic;
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
        [HttpGet]
        public string GetStudents(string orderBy)//metoda przekazujaca dane QueryString
        {
            return $"Natalia, Hania, Maciek{ orderBy }";
        }

        [HttpGet("{id}")]
        public IActionResult GetStudents(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            } else if (id == 2)
            {
                return Ok("Malewski");
            }
            return NotFound("Nie znaleziono studenta");
        }


        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
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
