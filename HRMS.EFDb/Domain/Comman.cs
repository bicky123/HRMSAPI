namespace HRMS.EFDb.Domain
{
    public class Comman
    {
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string Status { get; set; }
    }
}
