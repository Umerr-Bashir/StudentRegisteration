using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegisteration.Models
{
    public class WorkExperience
    {
        public Guid Id { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsCurrentJob { get; set; }
        public string JobDescription { get; set; }
        public Guid StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
