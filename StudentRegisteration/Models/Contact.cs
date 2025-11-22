using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegisteration.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhone { get; set; }
        public string WhatsappPhone { get; set; }
    }
}
