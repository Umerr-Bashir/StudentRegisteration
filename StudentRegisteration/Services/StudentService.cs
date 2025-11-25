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

            

            var response = await _uow.Students.CreateAsync(newRes);
            if (response == null)
                return new ApiResponse<StudentResponseDTO>(500, "No Response from Server.");

            var mappedStudent = _mapper.Map<StudentResponseDTO>(response);
                
            return new ApiResponse<StudentResponseDTO>(200, mappedStudent);
        }
        public async Task<ApiResponse<DocumentsResponseDto>> UploadAsync(StudentUploadDto studentDocs)
        {
            var newRes = _mapper.Map<Documents>(studentDocs);
            

            if (studentDocs.Documents != null)
            {
                newRes = new Documents
                {
                    StudentId = studentDocs.StudentId,
                    ExperienceCertificateUrls = new List<string>()
                };

                if (studentDocs.Documents.CNICFrontImageUrl != null)
                    newRes.CNICFrontImageUrl = await SaveFile(studentDocs.Documents.CNICFrontImageUrl, "Documents", studentDocs.StudentId.ToString());

                if (studentDocs.Documents.CNICBackImageUrl != null)
                    newRes.CNICBackImageUrl = await SaveFile(studentDocs.Documents.CNICBackImageUrl, "Documents", studentDocs.StudentId.ToString());
                
                if (studentDocs.Documents.MatricCertificateUrl != null)
                    newRes.MatricCertificateUrl = await SaveFile(studentDocs.Documents.MatricCertificateUrl, "Documents", studentDocs.StudentId.ToString());

                if (studentDocs.Documents.IntermediateCertificateUrl != null)
                    newRes.IntermediateCertificateUrl = await SaveFile(studentDocs.Documents.IntermediateCertificateUrl, "Documents", studentDocs.StudentId.ToString());

                if (studentDocs.Documents.BachelorCertificateUrl != null)
                    newRes.BachelorCertificateUrl = await SaveFile(studentDocs.Documents.BachelorCertificateUrl, "Documents", studentDocs.StudentId.ToString());

                if (studentDocs.Documents.ExperienceCertificateUrls != null)
                {
                    foreach (var file in studentDocs.Documents.ExperienceCertificateUrls)
                    {
                        var url = await SaveFile(file, "Documents", studentDocs.StudentId.ToString());
                        newRes.ExperienceCertificateUrls.Add(url);
                    }
                }
            }
            if (studentDocs.ProfileImageUrl != null)
            {
                newRes.ProfileImageUrl = await SaveFile(studentDocs.ProfileImageUrl, "ProfileImages", studentDocs.StudentId.ToString());
            }

            var response = await _uow.Students.UploadDocsAsync(newRes);
            if (response == null)
                return new ApiResponse<DocumentsResponseDto>(500, "No Response from Server.");

            var mappedDocs = _mapper.Map<DocumentsResponseDto>(response);
            return new ApiResponse<DocumentsResponseDto>(200, mappedDocs);

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
