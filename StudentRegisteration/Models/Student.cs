namespace StudentRegisteration.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string FullName { get; set; } 
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string CNIC { get; set; }
        public DateOnly CNICExpiry { get; set; }
        public bool isDeleted { get; set; }
        public string ProfileImageUrl { get; set; }

        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public Guardian Guardian { get; set; }
        public Emergency Emergency { get; set; }
        public Documents Documents { get; set; }
        public List<Education> Education { get; set; }
        public List<WorkExperience> WorkExperience { get; set; }
    }
}
