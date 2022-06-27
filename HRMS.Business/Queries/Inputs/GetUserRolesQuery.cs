using HRMS.Business.Queries.Results;
using HRMS.EFDb.Domain;
using MediatR;

namespace HRMS.Business.Queries.Inputs
{
    public record GetUserRolesQuery(ApplicationUser User) : IRequest<CommanResult<IList<string>>>;
}
