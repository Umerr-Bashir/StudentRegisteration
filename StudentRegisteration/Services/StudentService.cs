using AutoMapper;
using StudentRegisteration.Data;
using StudentRegisteration.DTOs;
using StudentRegisteration.DTOs.StudentDTO;
using StudentRegisteration.Models;

namespace StudentRegisteration.Services
{
    public class StudentService:IStudentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // GetAll
        public async Task<ApiResponse<List<StudentResponseDTO>>> GetAllAsync()
        {
            var response = await _uow.Students.GetAllAsync();
            if (response == null) {
                return new ApiResponse<List<StudentResponseDTO>>(200, "No Data Found!");
            }

            var mappedRes = _mapper.Map<List<StudentResponseDTO>>(response);
            return new ApiResponse<List<StudentResponseDTO>>(200, mappedRes);
        }
        // GEtById

        public async Task<ApiResponse<StudentResponseDTO>> GetById(Guid id)
        {
            var response = await _uow.Students.GetById(id);
            if (response == null) {
                return new ApiResponse<StudentResponseDTO>(200, "No Data Found!");
            }
            var mappedRes =  _mapper.Map<StudentResponseDTO>(response);
            return new ApiResponse<StudentResponseDTO>(200, mappedRes);
        }
        // Create
        public async Task<ApiResponse<StudentResponseDTO>> CreateAsync(StudentCreateDTO student)
        {
            var stu = _mapper.Map<Student>(student);

            var response = await _uow.Students.CreateAsync(stu);
            if (response == null)
            {
                return new ApiResponse<StudentResponseDTO>(500, "No Response from Server.");
            } 
            return new ApiResponse<StudentResponseDTO>(200, _mapper.Map<StudentResponseDTO>(response));
        }

        //Update
        public async Task<ApiResponse<StudentResponseDTO>> UpdateAsync(Guid id, StudentCreateDTO student)
        { 
            var myStudent = await _uow.Students.GetById(id);
            var response = await _uow.Students.UpdateAsync(myStudent);
            if(response == null)
            {
                return new ApiResponse<StudentResponseDTO>(500, "No Response from Server.");
            }
            var mappedStudent = _mapper.Map<StudentResponseDTO>(response);

            return new ApiResponse<StudentResponseDTO>(200, mappedStudent); 
        }

        // Delete
        public async Task<ApiResponse<ConfirmationResponse>> DeleteAsync(Guid id)
        {
            var myStudent = await _uow.Students.GetById(id);
            var response = await _uow.Students.DeleteAsync(myStudent);
            if (response == false)
            {
                return new ApiResponse<ConfirmationResponse>(400, "Unable to Safe Delete Record. ");
            }
            return new ApiResponse<ConfirmationResponse>(200, "Record Safe Deleted Successfully.");
        }
    }
}
