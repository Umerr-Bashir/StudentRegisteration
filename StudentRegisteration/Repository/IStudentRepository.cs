using StudentRegisteration.DTOs.StudentDTO;
using StudentRegisteration.Models;

namespace StudentRegisteration.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetById(Guid id);
        Task<Student> CreateAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task<bool> DeleteAsync(Student student);
    }
}
