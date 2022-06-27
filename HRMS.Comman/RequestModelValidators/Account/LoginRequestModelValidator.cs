using FluentValidation;
using HRMS.Comman.RequestModels.Account;

namespace HRMS.Comman.RequestModelValidators.Account
{
    public class LoginRequestModelValidator : AbstractValidator<LoginRequestModel>
    {
        public LoginRequestModelValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email invalid");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password required");
        }
    }
}
