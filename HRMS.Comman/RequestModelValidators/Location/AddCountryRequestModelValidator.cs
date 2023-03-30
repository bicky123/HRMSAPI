using FluentValidation;
using HRMS.Comman.RequestModels.Location;

namespace HRMS.Comman.RequestModelValidators.Location;
public class AddCountryRequestModelValidator : AbstractValidator<AddCountryRequestModel>
{
	public AddCountryRequestModelValidator()
	{
		RuleFor(x => x.Name)
			.Empty().WithMessage("Country Name is required")
			.MinimumLength(3).WithMessage("Country Name should be greater than 2 char")
			.MaximumLength(30).WithMessage("Country Name should be less than 29 char");

		RuleFor(x => x.Code)
			.Empty().WithMessage("Country Code is required")
			.Length(3).WithMessage("Country Code should be 3 char");

		RuleFor(x => x.IsActive)
			.Empty().WithMessage("IsActive is required");

	}
}
