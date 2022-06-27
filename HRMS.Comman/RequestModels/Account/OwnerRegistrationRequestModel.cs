namespace HRMS.Comman.RequestModels.Account
{
    public class OwnerRegistrationRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HouseNo { get; set; }
        public string ZipCode { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
