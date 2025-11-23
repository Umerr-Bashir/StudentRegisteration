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
        private readonly IWebHostEnvironment _env;

        public StudentService(IUnitOfWork uow, IMapper mapper, IWebHostEnvironment _env)
        {
            _uow = uow;
            _mapper = mapper;
            this._env = _env ?? throw new ArgumentNullException(nameof(_env));

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
                return new ApiResponse<StudentResponseDTO>(500, "No Response from Server.");

            async Task<string> SaveFile(IFormFile file, string folder, string studentId)
            {
                var folderPath = Path.Combine(_env.WebRootPath, folder, studentId);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                var fullPath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return $"/{folder}/{studentId}/{fileName}";
            }

            if (student.ProfileImageUrl != null)
            {
                response.ProfileImageUrl = await SaveFile(student.ProfileImageUrl, "ProfileImages", response.Id.ToString());
            }

            if (student.Documents != null)
            {
                var docs = new Documents
                {
                    StudentId = response.Id,
                    ExperienceCertificateUrls = new List<string>()
                };

                if (student.Documents.CNICFrontImageUrl != null)
                    docs.CNICFrontImageUrl = await SaveFile(student.Documents.CNICFrontImageUrl, "Documents", response.Id.ToString());

                if (student.Documents.CNICBackImageUrl != null)
                    docs.CNICBackImageUrl = await SaveFile(student.Documents.CNICBackImageUrl, "Documents", response.Id.ToString());

                if (student.Documents.MatricCertificateUrl != null)
                    docs.MatricCertificateUrl = await SaveFile(student.Documents.MatricCertificateUrl, "Documents", response.Id.ToString());

                if (student.Documents.IntermediateCertificateUrl != null)
                    docs.IntermediateCertificateUrl = await SaveFile(student.Documents.IntermediateCertificateUrl, "Documents", response.Id.ToString());

                if (student.Documents.BachelorCertificateUrl != null)
                    docs.BachelorCertificateUrl = await SaveFile(student.Documents.BachelorCertificateUrl, "Documents", response.Id.ToString());

                if (student.Documents.ExperienceCertificateUrls != null)
                {
                    foreach (var file in student.Documents.ExperienceCertificateUrls)
                    {
                        var url = await SaveFile(file, "Documents", response.Id.ToString());
                        docs.ExperienceCertificateUrls.Add(url);
                    }
                }

            }
            var mappedStudent = _mapper.Map<StudentResponseDTO>(response);
            if (student.Documents != null)
                mappedStudent.Documents = _mapper.Map<DocumentsDto>(student.Documents);

            return new ApiResponse<StudentResponseDTO>(200, mappedStudent);
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
