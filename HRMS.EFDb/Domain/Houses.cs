namespace HRMS.EFDb.Domain
{
    public class Houses : Comman
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string HouseName { get; set; }
        public string HouseNo { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string ZipCode { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
