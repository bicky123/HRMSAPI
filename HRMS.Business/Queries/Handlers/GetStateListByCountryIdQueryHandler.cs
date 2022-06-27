using AutoMapper;
using HRMS.Business.Queries.Inputs;
using HRMS.Business.Queries.Results;
using HRMS.EFDb.UnitsOfWork;
using MediatR;

namespace HRMS.Business.Queries.Handlers
{
    public class GetStateListByCountryIdQueryHandler : IRequestHandler<GetStateListByCountryIdQuery, CommanResult<List<GetStateListByCountryIdQueryResult>>>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public GetStateListByCountryIdQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<CommanResult<List<GetStateListByCountryIdQueryResult>>> Handle(GetStateListByCountryIdQuery request, CancellationToken cancellationToken)
        {
            var state = await _unit.State.FindAsync(s => s.CountryId == request.CountryId);
            var getStateList = _mapper.Map<List<GetStateListByCountryIdQueryResult>>(state);
            return new CommanResult<List<GetStateListByCountryIdQueryResult>>(getStateList, null);
        }
    }
}
