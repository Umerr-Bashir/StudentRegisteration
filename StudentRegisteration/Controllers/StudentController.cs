using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegisteration.DTOs;
using StudentRegisteration.DTOs.StudentDTO;
using StudentRegisteration.Services;
using System.Reflection.Metadata.Ecma335;

namespace StudentRegisteration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<ApiResponse<List<StudentResponseDTO>>>> GetAllStudents()
        {
            var response = await _studentService.GetAllAsync();
            if (response.StatusCode != 200)
            {
                return StatusCode((int)response.StatusCode, response);
            }
            return Ok(response);
        }

        [HttpGet("GetStudentById/{id}")]
        public async Task<ActionResult<ApiResponse<StudentResponseDTO>>> GetStudentById(Guid id)
        {
            if (id != Guid.Empty)
            {
                var response = await _studentService.GetById(id);
                if (response.StatusCode != 200)
                {
                    return StatusCode((int)response.StatusCode, response);
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Id is Null.");
            }
        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult<ApiResponse<StudentResponseDTO>>> CreateStudent([FromBody] StudentCreateDTO student)
        {
            if (student != null)
            {
                var response = await _studentService.CreateAsync(student);
                if (response.StatusCode != 200)
                {
                    return StatusCode((int)response.StatusCode, response);
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Invalid Input.");
            }
        }

        [HttpPost("UploadDocuments")]
        public async Task<ActionResult<ApiResponse<DocumentsResponseDto>>> UploadDocuments([FromForm] StudentUploadDto document)
        {
            if (document != null)
            {
                var response = await _studentService.UploadAsync(document);
                if (response.StatusCode != 200)
                {
                    return StatusCode((int)response.StatusCode, response);
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Invalid Input.");
            }
        }

        [HttpPost("UpdateStudent/{id}")]
        public async Task<ActionResult<ApiResponse<StudentResponseDTO>>> UpdateStudent(Guid id, StudentCreateDTO student)
        {
            if (student != null && id != Guid.Empty) {

                var response = await _studentService.UpdateAsync(id, student);
                if (response.StatusCode != 200)
                {
                    return StatusCode((int)response.StatusCode, response);
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Invalid input.");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ApiResponse<ConfirmationResponse>>> DeleteAsync(Guid id)
        {
            if (id != Guid.Empty) {
                var response = await _studentService.DeleteAsync(id);
                if (response.StatusCode!=200)
                {
                    return StatusCode((int)response.StatusCode, response);
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Invalid Input.");
            }
        }

        [HttpGet("download/{*filePath}")]
        public IActionResult DownloadFile(string filePath)
        {
            filePath = filePath.TrimStart('/'); 

            var fullPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                filePath
            );

            if (!System.IO.File.Exists(fullPath))
                return NotFound();

            var fileName = Path.GetFileName(fullPath);

            return PhysicalFile(fullPath, "application/octet-stream", fileName);
        }



    }
}
