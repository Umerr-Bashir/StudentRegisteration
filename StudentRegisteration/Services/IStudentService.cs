using StudentRegisteration.DTOs;
using StudentRegisteration.DTOs.StudentDTO;

namespace StudentRegisteration.Services
{
    public interface IStudentService
    {
        Task<ApiResponse<List<StudentResponseDTO>>> GetAllAsync();
        Task<ApiResponse<StudentResponseDTO>> GetById(Guid id);
        Task<ApiResponse<StudentResponseDTO>> CreateAsync(StudentCreateDTO student);
        Task<ApiResponse<StudentResponseDTO>> UpdateAsync(Guid id, StudentCreateDTO student);
        Task<ApiResponse<ConfirmationResponse>> DeleteAsync(Guid id);
    }
}
