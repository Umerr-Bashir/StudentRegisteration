using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegisteration.Models
{
    public class Documents
    {
        public IFormFile CNICFrontImageUrl { get; set; }
        public IFormFile CNICBackImageUrl { get; set; }
        public IFormFile MatricCertificateUrl { get; set; }
        public IFormFile IntermediateCertificateUrl { get; set; }
        public IFormFile BachelorCertificateUrl { get; set; }
        public List<IFormFile> ExperienceCertificateUrls { get; set; }
        public Guid StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
