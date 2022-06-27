namespace HRMS.EFDb.Domain
{
    public class Owners : Comman
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string ZipCode { get; set; }
        public string HouseNo { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
