using FirstWritingAPI.Models;
using FirstWritingAPI.Repositories.Interfaces;
using FirstWritingAPI.Services.Interfaces;

namespace FirstWritingAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student? GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public Student CreateStudent(Student student)
        {
            return _studentRepository.Add(student);
        }

        public bool UpdateStudent(int id, Student updatedStudent)
        {
            return _studentRepository.Update(id, updatedStudent);
        }

        public bool DeleteStudent(int id)
        {
            return _studentRepository.Delete(id);
        }
    }
}