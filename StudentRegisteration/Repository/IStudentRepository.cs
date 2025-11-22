using StudentRegisteration.DTOs.StudentDTO;
using StudentRegisteration.Models;

namespace StudentRegisteration.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetById(Guid id);
        Task<bool> CreateAsync(StudentCreateDTO student);
        Task<bool> UpdateAsync(Student student);
        Task<bool> DeleteAsync(Student student);
    }
}
