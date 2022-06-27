using HRMS.Business.Queries.Results;
using MediatR;

namespace HRMS.Business.Queries.Inputs
{
    public record FindUserByEmailQuery(string Email) : IRequest<CommanResult<FindUserByEmailQueryResult>>;
}
