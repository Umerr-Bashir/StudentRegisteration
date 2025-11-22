using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<StudentResponseDTO>>> GetAllStudents()
        {
            var response = await _studentService.GetAllAsync();
            if (response == null)
            {
                return BadRequest("No Response from Server.");
            }
            return Ok(response);
        }

        [HttpGet("GetStudentById/{id}")]
        public async Task<ActionResult<StudentResponseDTO>> GetStudentById(Guid id)
        {
            if (id != Guid.Empty)
            {
                var response = await _studentService.GetById(id);
                if (response == null)
                {
                    return BadRequest("No Response from Server.");
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Id is Null.");
            }
        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult<bool>> CreateStudent(StudentCreateDTO student)
        {
            if (student != null)
            {
                var response = await _studentService.CreateAsync(student);
                if (!response)
                {
                    return false;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Invalid Input.");
            }
        }

        [HttpPost("UpdateStudent/{id}")]
        public async Task<ActionResult<StudentResponseDTO>> UpdateStudent(Guid id,StudentCreateDTO student)
        {
            if (student != null && id != Guid.Empty) {

                var response = await _studentService.UpdateAsync(id, student);
                if (response == null)
                {
                    return BadRequest("No Response from Server.");
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Invalid input.");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            if (id != Guid.Empty) {
                var response = await _studentService.DeleteAsync(id);
                if (!response)
                {
                    return false;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Invalid Input.");
            }
        }

    }
}
