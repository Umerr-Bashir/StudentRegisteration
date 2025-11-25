using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegisteration.Models
{
    public class Documents
    {
        [Key] 
        public Guid? Id { get; set; } = Guid.NewGuid();
        public string ProfileImageUrl { get; set; }

        public string? CNICFrontImageUrl { get; set; }
        public string? CNICBackImageUrl { get; set; }
        public string? MatricCertificateUrl { get; set; }
        public string? IntermediateCertificateUrl { get; set; }
        public string? BachelorCertificateUrl { get; set; }
        public List<string> ExperienceCertificateUrls { get; set; }
        public Guid? StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
