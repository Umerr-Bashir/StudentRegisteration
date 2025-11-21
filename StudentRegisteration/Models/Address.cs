namespace StudentRegisteration.Models
{
    public class Address
    {
        public Guid Id { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string FullAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public bool IsSameAsPermanentAddress { get; set; }
        public Student Student { get; set; }
    }
}
