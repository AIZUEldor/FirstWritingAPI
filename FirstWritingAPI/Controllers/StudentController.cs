using Microsoft.AspNetCore.Mvc;
using FirstWritingAPI.Data;
namespace FirstWritingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(_context.Students.ToList());
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateStudentById(int id, Student updatedStudent)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteStudentById(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            return NoContent();
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}