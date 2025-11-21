using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using StudentRegisteration.Models;

namespace StudentRegisteration.Data
{
    public class ApplicationDbContext (DbContextOptions options): DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var Relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                Relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Emergency> Emergencies { get; set; }
        public DbSet<Guardian> Guardians { get; set; }

    }
}
