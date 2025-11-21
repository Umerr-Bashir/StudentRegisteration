using AutoMapper;
using StudentRegisteration.DTOs.StudentDTO;
using StudentRegisteration.Models;

namespace StudentRegisteration.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentCreateDTO, Student>()
                .ForMember(dest => dest)
        }
    }
}
