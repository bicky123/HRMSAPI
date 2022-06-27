using FluentValidation.Results;

namespace HRMS.Comman.Utility
{
    public static class CommanUtility
    {
        public static List<string> GetFluentValidationErrorMessages(List<ValidationFailure> failures)
        {
            var errors = (from error in failures
                          select error.ErrorMessage).ToList();
            return errors;
        }
    }
}
