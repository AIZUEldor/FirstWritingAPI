using FirstWritingAPI.Models;

namespace FirstWritingAPI.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student? GetById(int id);
        Student Add(Student student);
        bool Update(int id, Student updatedStudent);
        bool Delete(int id);
    }
}