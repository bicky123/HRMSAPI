using Microsoft.AspNetCore.Identity;

namespace HRMS.EFDb.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string Status { get; set; }
    }
}
