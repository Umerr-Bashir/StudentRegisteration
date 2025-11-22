using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentRegisteration.Data;
using StudentRegisteration.DTOs.StudentDTO;
using StudentRegisteration.Models;
using System.Runtime.InteropServices;

namespace StudentRegisteration.Repository
{
    public class StudentRepository: IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var res=  await _context.Students
                .Include(a=>a.Address)
                .Include(c=>c.Contact)
                .Include(g=>g.Guardian)
                .Include(e=>e.Emergency)
                .Include(d=>d.Education)
                .Include(w=>w.WorkExperience)
                .ToListAsync();
            return res;
        }

        public async Task<Student> GetById(Guid id)
        {
            var res = await _context.Students
                .Include(a => a.Address)
                .Include(c => c.Contact)
                .Include(g => g.Guardian)
                .Include(e => e.Emergency)
                .Include(d => d.Education)
                .Include(w => w.WorkExperience).FirstOrDefaultAsync(s=>s.Id==id);
            if (res==null)
                return null;
            return res;
        }

        public async Task<bool> CreateAsync(StudentCreateDTO student)
        {
            if (student != null) {
                if (_mapper == null) throw new Exception("_mapper is NULL");

                var studentMapped = _mapper.Map<Student>(student);
                studentMapped.FullName = student.FirstName +" "+ student.LastName;
                if (studentMapped == null) throw new Exception("studentMapped is NULL");
                await _context.Students.AddAsync(studentMapped);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public async Task<bool> UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Student student)
        {
            //_context.Students.Remove(student);
            student.isDeleted = false;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}
