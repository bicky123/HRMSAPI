using HRMS.Business.Queries.Results;
using MediatR;

namespace HRMS.Business.Queries.Inputs
{
    public record GetCountryListQuery() : IRequest<CommanResult<List<GetCountryListQueryResult>>>;
}
