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

        public async Task<Student> CreateAsync(Student student)
        {
            student.FullName = student.FirstName + " " + student.LastName;
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student; 
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
