using HRMS.Business.Queries.Results;
using MediatR;

namespace HRMS.Business.Queries.Inputs
{
    public record GetStateListByCountryIdQuery(int CountryId) : IRequest<CommanResult<List<GetStateListByCountryIdQueryResult>>>;
}
