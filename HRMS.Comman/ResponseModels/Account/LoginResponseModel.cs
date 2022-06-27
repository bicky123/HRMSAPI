namespace HRMS.Comman.ResponseModels.Account
{
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
