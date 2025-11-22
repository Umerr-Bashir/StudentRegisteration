using AutoMapper;
using StudentRegisteration.Data;
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

        public async Task<List<StudentResponseDTO>> GetAllAsync()
        {
            var response = await _uow.Students.GetAllAsync();
            if (response == null) {
                return null;
            }
            return _mapper.Map<List<StudentResponseDTO>>(response);
        }

        public async Task<StudentResponseDTO> GetById(Guid id)
        {
            var response = await _uow.Students.GetById(id);
            if (response == null) {
                return null;
            }
            return _mapper.Map<StudentResponseDTO>(response);
        }
        public async Task<bool> CreateAsync(StudentCreateDTO student)
        {
            var response = await _uow.Students.CreateAsync(student);
            if (response == false)
            {
                return false;
            } 
            return true;
        }

        public async Task<StudentResponseDTO> UpdateAsync(Guid id, StudentCreateDTO student)
        {
            var myStudent = await _uow.Students.GetById(id);
            var mappedStudent = _mapper.Map<Student>(student);
            var response = await _uow.Students.UpdateAsync(myStudent);
            return _mapper.Map<StudentResponseDTO>(student);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var myStudent = await _uow.Students.GetById(id);
            var response = await _uow.Students.DeleteAsync(myStudent);
            if (response == false)
            {
                return false;
            }
            return true;
        }
    }
}
