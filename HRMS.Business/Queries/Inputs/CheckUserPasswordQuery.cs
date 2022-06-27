using HRMS.Business.Queries.Results;
using MediatR;

namespace HRMS.Business.Queries.Inputs
{
    public record CheckUserPasswordQuery(FindUserByEmailQueryResult model, string password) : IRequest<bool>;
}
