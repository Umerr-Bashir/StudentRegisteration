using StudentRegisteration.Models;

namespace StudentRegisteration.DTOs.StudentDTO
{
    public class StudentResponseDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string CNIC { get; set; }
        public DateOnly CNICExpiry { get; set; }
        public bool isDeleted { get; set; }

        public string ProfileImageUrl { get; set; }

        public AddressDto Address { get; set; }
        public ContactDto Contact { get; set; }
        public GuardianDto Guardian { get; set; }
        public EmergencyContactDto Emergency { get; set; }
        public DocumentsDto Documents { get; set; }
        public List<EducationDto> Education { get; set; }
        public List<WorkExperienceDto> WorkExperience { get; set; }
    }
}
