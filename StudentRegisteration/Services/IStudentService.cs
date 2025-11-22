using StudentRegisteration.DTOs.StudentDTO;

namespace StudentRegisteration.Services
{
    public interface IStudentService
    {
        Task<List<StudentResponseDTO>> GetAllAsync();
        Task<StudentResponseDTO> GetById(Guid id);
        Task<bool> CreateAsync(StudentCreateDTO student);
        Task<StudentResponseDTO> UpdateAsync(Guid id,StudentCreateDTO student);
        Task<bool> DeleteAsync(Guid id);
    }
}
