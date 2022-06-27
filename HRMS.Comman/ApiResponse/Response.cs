using Microsoft.AspNetCore.Identity;

namespace HRMS.Comman.ApiResponse
{
    public class Response
    {
        public bool Success { get; }
        public int StatusCode { get; }
        public string Message { get; }
        public List<string> Errors { get; }

        public Response(int statusCode, string message = "", List<string> errors = null)
        {
            this.Success = CheckStatusCode(statusCode);
            this.StatusCode = statusCode;
            this.Message = message;
            Errors = errors == null ? new List<string>() : errors;
            //if (errors != null )
            //{
            //    this.Errors = AddErrors(errors);
            //}
        }

        private bool CheckStatusCode(int code)
        {
            switch (code)
            {
                case 200:
                    return true;
                case 201:
                    return true;
                case 202:
                    return true;
                case 204:
                    return true;
                default:
                    return false;
            }
        }

        private List<string> AddErrors(IdentityResult result)
        {
            var errors = new List<string>();
            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }
            return errors;
        }
    }
}
