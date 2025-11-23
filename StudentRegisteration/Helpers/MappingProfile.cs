using AutoMapper;
using StudentRegisteration.DTOs.StudentDTO;
using StudentRegisteration.Models;

namespace StudentRegisteration.Helpers
{
    public class MappingProfile:Profile
    {
            private readonly string _baseUrl = "https://localhost:7290/";
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
                CreateMap<DocumentsCreateDto, Documents>().ReverseMap();
                CreateMap<DocumentsResponseDto, Documents>().ReverseMap();
                CreateMap<DocumentsCreateDto, DocumentsResponseDto>().ReverseMap();
                CreateMap<Student, StudentResponseDTO>().ReverseMap();

            // Adding BaseUrl Start of each Path
                CreateMap<Student, StudentResponseDTO>()
                    .ForMember(dest => dest.ProfileImageUrl, opt => opt.MapFrom(p => $"{_baseUrl}{p.ProfileImageUrl}"))
                    .ForMember(dest => dest.Documents, opt => opt.MapFrom(d => new DocumentsResponseDto
                    {
                        CNICFrontImageUrl = $"{_baseUrl}{d.Documents.CNICFrontImageUrl}",
                        CNICBackImageUrl = $"{_baseUrl}{d.Documents.CNICBackImageUrl}",
                        MatricCertificateUrl = $"{_baseUrl}{d.Documents.MatricCertificateUrl}",
                        IntermediateCertificateUrl = $"{_baseUrl}{d.Documents.IntermediateCertificateUrl}",
                        BachelorCertificateUrl = $"{_baseUrl}{d.Documents.BachelorCertificateUrl}",
                        ExperienceCertificateUrls = d.Documents.ExperienceCertificateUrls
                        .Select(u=> $"{_baseUrl}{u}").ToList()
                    }));
            }
    }
}
