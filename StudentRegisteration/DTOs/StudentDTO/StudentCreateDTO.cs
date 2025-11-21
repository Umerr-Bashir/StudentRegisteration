namespace StudentRegisteration.DTOs.StudentDTO
{
    public class StudentCreateDTO
    {
        // Personal Info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string CNIC { get; set; }
        public DateTime CNICExpiry { get; set; }
        public string ProfileImageUrl { get; set; }

        public AddressDto Address { get; set; }

        // Contact Info
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string WhatsAppNumber { get; set; }



        // Parent/Guardian
        public string FatherCNIC { get; set; }
        public string FatherOccupation { get; set; }
        public string FatherPhone { get; set; }
        public string MotherPhone { get; set; }
        public string GuardianName { get; set; }
        public string GuardianRelation { get; set; }
        public string GuardianPhone { get; set; }

        // Emergency Contact
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelation { get; set; }
        public string EmergencyContactPhone { get; set; }
    }
   class AddressDto
    {
        // Address Info
        public string Country { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string FullAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public bool IsSameAsPermanentAddress { get; set; }
    }
}
