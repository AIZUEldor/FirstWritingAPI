using FirstWritingAPI.Models;

namespace FirstWritingAPI.Services.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student? GetStudentById(int id);
        Student CreateStudent(Student student);
        bool UpdateStudent(int id, Student updatedStudent);
        bool DeleteStudent(int id);
    }
}