namespace StudentRegisteration.Models
{
    public class Emergency
    {
        public Guid Id { get; set; }
        public Student Student { get; set; }
        public int? EmergencyContactName { get; set; }
        public int? EmergencyContactRelation { get; set; }
        public int? EmergencyContactPhone { get; set; }
    }
}
