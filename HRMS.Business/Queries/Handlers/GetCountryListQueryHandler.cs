using AutoMapper;
using HRMS.Business.Queries.Inputs;
using HRMS.Business.Queries.Results;
using HRMS.EFDb.UnitsOfWork;
using MediatR;

namespace HRMS.Business.Queries.Handlers
{
    public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, CommanResult<List<GetCountryListQueryResult>>>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        public GetCountryListQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<CommanResult<List<GetCountryListQueryResult>>> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
        {
            var countries = await _unit.Country.GetAsync();
            var getCountryLists = _mapper.Map<List<GetCountryListQueryResult>>(countries);
            return new CommanResult<List<GetCountryListQueryResult>>(getCountryLists, null);
        }
    }
}
