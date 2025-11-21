using Microsoft.EntityFrameworkCore;
using StudentRegisteration.Data;
using StudentRegisteration.DTOs.StudentDTO;
using StudentRegisteration.Models;

namespace StudentRegisteration.Repository
{
    public class StudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students
                .Include(a=>a.Address)
                .Include(c=>c.Contact)
                .Include(g=>g.Guardian)
                .Include(e=>e.Emergency)
                .ToListAsync();
        }

        public async Task<Student> GetById(Guid id)
        {
            return await _context.Students
                .Include(a => a.Address)
                .Include(c => c.Contact)
                .Include(g => g.Guardian)
                .Include(e => e.Emergency).FirstOrDefaultAsync(s=>s.Id==id);
        }

        public async Task AddAsync(StudentCreateDTO student)
        {
            await _context.Students.AddAsync(student);
        }
    }
}
