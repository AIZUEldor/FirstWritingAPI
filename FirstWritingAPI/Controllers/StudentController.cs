using Microsoft.AspNetCore.Mvc;
using FirstWritingAPI.Models;
using FirstWritingAPI.Services.Interfaces;

namespace FirstWritingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student)
        {
            var createdStudent = _studentService.CreateStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudentById(int id, Student updatedStudent)
        {
            var result = _studentService.UpdateStudent(id, updatedStudent);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudentById(int id)
        {
            var result = _studentService.DeleteStudent(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}