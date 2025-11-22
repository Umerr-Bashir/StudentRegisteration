using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegisteration.Models
{
    public class Education
    {
        public Guid Id { get; set; }
        public string DegreeName { get; set; }
        public string MajorSubject { get; set; }
        public string Grade { get; set; }
        public string InstituteName { get; set; }
        public string BoardOrUniversity { get; set; }
        public int PassingYear { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string CompletionStatus { get; set; }
        public Guid StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
