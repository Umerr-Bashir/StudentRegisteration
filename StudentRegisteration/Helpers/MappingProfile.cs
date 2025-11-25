using AutoMapper;
using StudentRegisteration.DTOs.StudentDTO;
using StudentRegisteration.Models;

namespace StudentRegisteration.Helpers
{
    public class MappingProfile : Profile
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
            CreateMap<StudentCreateDTO, Student>()
            .ForMember(dest => dest.Education, opt => opt.MapFrom(src => src.Education))
            .ForMember(dest => dest.WorkExperience, opt => opt.MapFrom(src => src.WorkExperience));
            CreateMap<StudentResponseDTO, Student>().ReverseMap();
            CreateMap<DocumentsCreateDto, Documents>().ReverseMap();
            CreateMap<DocumentsResponseDto, Documents>().ReverseMap();
            CreateMap<DocumentsCreateDto, DocumentsResponseDto>().ReverseMap();
            CreateMap<Student, StudentResponseDTO>().ReverseMap();

            // Adding BaseUrl Start of each Path
            CreateMap<Student, StudentResponseDTO>().ReverseMap();
            CreateMap<StudentUploadDto, Documents>().ReverseMap();
                CreateMap<Documents, DocumentsResponseDto>()
                    .ForMember(dest => dest.ProfileImageUrl,
                        opt => opt.MapFrom(p => $"{_baseUrl}download{p.ProfileImageUrl}"))
                    .ForMember(dest => dest.CNICBackImageUrl,
                        opt => opt.MapFrom(d => $"{_baseUrl}download{d.CNICBackImageUrl}"))
                    .ForMember(dest => dest.CNICFrontImageUrl,
                        opt => opt.MapFrom(d => $"{_baseUrl}download{d.CNICFrontImageUrl}"))
                    .ForMember(dest => dest.MatricCertificateUrl,
                        opt => opt.MapFrom(d => $"{_baseUrl}download{d.MatricCertificateUrl}"))
                    .ForMember(dest => dest.IntermediateCertificateUrl,
                        opt => opt.MapFrom(d => $"{_baseUrl}download{d.IntermediateCertificateUrl}"))
                    .ForMember(dest => dest.BachelorCertificateUrl,
                        opt => opt.MapFrom(d => $"{_baseUrl}download{d.BachelorCertificateUrl}"))
                    .ForMember(dest => dest.ExperienceCertificateUrls,
                        opt => opt.MapFrom(d =>
                            d.ExperienceCertificateUrls.Select(u => $"{_baseUrl}download{u}").ToList()
                        ));



        }
    }
}
