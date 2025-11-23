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

            var studentId = Guid.NewGuid();

            var newRes = _mapper.Map<Student>(student);
            newRes.Id = studentId;

            if (student.ProfileImageUrl != null)
            {
                newRes.ProfileImageUrl = await SaveFile(student.ProfileImageUrl, "ProfileImages", studentId.ToString());

            }

            if (student.Documents != null)
            {
                newRes.Documents = new Documents
                {
                    StudentId = studentId,
                    ExperienceCertificateUrls = new List<string>()
                };
                
                if (student.Documents.CNICFrontImageUrl != null)
                    newRes.Documents.CNICFrontImageUrl = await SaveFile(student.Documents.CNICFrontImageUrl, "Documents", studentId.ToString());

                if (student.Documents.CNICBackImageUrl != null)
                    newRes.Documents.CNICBackImageUrl = await SaveFile(student.Documents.CNICBackImageUrl, "Documents", studentId.ToString());

                if (student.Documents.MatricCertificateUrl != null)
                    newRes.Documents.MatricCertificateUrl = await SaveFile(student.Documents.MatricCertificateUrl, "Documents", studentId.ToString());

                if (student.Documents.IntermediateCertificateUrl != null)
                    newRes.Documents.IntermediateCertificateUrl = await SaveFile(student.Documents.IntermediateCertificateUrl, "Documents", studentId.ToString());

                if (student.Documents.BachelorCertificateUrl != null)
                    newRes.Documents.BachelorCertificateUrl = await SaveFile(student.Documents.BachelorCertificateUrl, "Documents", studentId.ToString());

                if (student.Documents.ExperienceCertificateUrls != null)
                {
                    foreach (var file in student.Documents.ExperienceCertificateUrls)
                    {
                        var url = await SaveFile(file, "Documents", studentId.ToString());
                        newRes.Documents.ExperienceCertificateUrls.Add(url);
                    }
                }

            }

            var response = await _uow.Students.CreateAsync(newRes);
            if (response == null)
                return new ApiResponse<StudentResponseDTO>(500, "No Response from Server.");

            var mappedStudent = _mapper.Map<StudentResponseDTO>(response);
                
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


        // SaveFile
        public async Task<string> SaveFile(IFormFile file, string folder, string studentId)
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
    }
}
