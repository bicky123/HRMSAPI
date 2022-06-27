using HRMS.Business.Queries.Inputs;
using HRMS.Business.Queries.Results;
using HRMS.EFDb.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRMS.Business.Queries.Handlers
{
    public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, CommanResult<IList<string>>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserRolesQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CommanResult<IList<string>>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _userManager.GetRolesAsync(request.User);
            return new CommanResult<IList<string>>(roles, null);
        }
    }
}
