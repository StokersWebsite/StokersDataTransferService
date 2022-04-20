namespace DTOLayer
{
    public class MemberDTO
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly Birthdate { get; set; }
        public string? Adress { get; set; }
        public string? PostalCode { get; set; }
    }
}