using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegisteration.Models
{
    public class Guardian
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public string FatherName { get; set; }
        public string FatherCNIC { get; set; }
        public string FatherOccupation { get; set; }
        public string FatherPhone { get; set; }
        public string MotherPhone { get; set; }
        public string GuardianName { get; set; }
        public string GuardianRelation { get; set; }
        public string GuardianPhone { get; set; }
    }
}
