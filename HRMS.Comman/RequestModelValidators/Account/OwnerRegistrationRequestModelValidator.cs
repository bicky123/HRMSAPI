using FluentValidation;
using HRMS.Comman.RequestModels.Account;

namespace HRMS.Comman.RequestModelValidators.Account
{
    public class OwnerRegistrationRequestModelValidator : AbstractValidator<OwnerRegistrationRequestModel>
    {
        public OwnerRegistrationRequestModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Name required");

            RuleFor(x => x.LastName)
                .Length(3, 100)
                .WithMessage("Min 3 char & max 100 char name required");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone required");

            RuleFor(x => x.Phone)
                .Matches(@"^[6-9][0-9]{9}$")
                .WithMessage("Phone invalid");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email required");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email invalid");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password required");

            RuleFor(x => x.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,50}$")
                .WithMessage("Password invalid");
        }
    }
}
