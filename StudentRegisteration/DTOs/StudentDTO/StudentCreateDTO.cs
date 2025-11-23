namespace StudentRegisteration.DTOs.StudentDTO
{
    public class StudentCreateDTO
    {
        // Personal Info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string CNIC { get; set; }
        public DateOnly CNICExpiry { get; set; }
        public IFormFile ProfileImageUrl { get; set; }
        public AddressDto Address { get; set; }
        public ContactDto Contact { get; set; }
        public GuardianDto Guardian { get; set; }
        public EmergencyContactDto Emergency { get; set; }
        public DocumentsDto Documents { get; set; }
        public List<EducationDto> Education { get; set; }
        public List<WorkExperienceDto> WorkExperience { get; set; }
    }
    public class EmergencyContactDto {
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelation { get; set; }
        public string EmergencyContactPhone { get; set; }
    }
    public class GuardianDto {
        public string FatherName { get; set; }
        public string FatherCNIC { get; set; }
        public string FatherOccupation { get; set; }
        public string FatherPhone { get; set; }
        public string MotherPhone { get; set; }
        public string GuardianName { get; set; }
        public string GuardianRelation { get; set; }
        public string GuardianPhone { get; set; }

    }
    public class ContactDto {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhone { get; set; }
        public string WhatsAppPhone { get; set; }
    }
    public class AddressDto
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public string FullAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public bool IsSameAsPermanentAddress { get; set; }
    }
    public class EducationDto
    {
        public string DegreeName { get; set; }
        public string MajorSubject { get; set; }
        public string Grade { get; set; }
        public string InstituteName { get; set; }
        public string BoardOrUniversity { get; set; }
        public int PassingYear { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string CompletionStatus { get; set; }
    }
    public class WorkExperienceDto
    {
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsCurrentJob { get; set; }
        public string JobDescription { get; set; }
    }
    public class DocumentsDto
    {
        public IFormFile CNICFrontImageUrl { get; set; }
        public IFormFile CNICBackImageUrl { get; set; }
        public IFormFile MatricCertificateUrl { get; set; }
        public IFormFile IntermediateCertificateUrl { get; set; }
        public IFormFile BachelorCertificateUrl { get; set; }
        public List<IFormFile> ExperienceCertificateUrls { get; set; }

    }


}
