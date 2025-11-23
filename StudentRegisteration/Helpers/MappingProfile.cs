using AutoMapper;
using StudentRegisteration.DTOs.StudentDTO;
using StudentRegisteration.Models;

namespace StudentRegisteration.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<EmergencyContactDto, Emergency>().ReverseMap();
            CreateMap<GuardianDto, Guardian>().ReverseMap();
            CreateMap<EducationDto, Education>().ReverseMap();
            CreateMap<WorkExperienceDto, WorkExperience>().ReverseMap();
            CreateMap<ContactDto, Contact>().ReverseMap();
            CreateMap<StudentCreateDTO, Student>().ReverseMap();
            CreateMap<StudentResponseDTO, Student>().ReverseMap();
            CreateMap<Student, StudentResponseDTO>().ReverseMap();
            CreateMap<DocumentsDto, Documents>().ReverseMap();
        }
    }
}
