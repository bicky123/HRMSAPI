using AutoMapper;
using HRMS.Business.Queries.Results;
using HRMS.EFDb.Domain;

namespace HRMS.Business.Queries.InputResultMapper
{
    public class QueryResultMapperProfile : Profile
    {
        public QueryResultMapperProfile()
        {
            CreateMap<ApplicationUser, FindUserByEmailQueryResult>().ReverseMap();
            CreateMap<Country, GetCountryListQueryResult>().ReverseMap();
            CreateMap<State, GetStateListByCountryIdQueryResult>().ReverseMap();
        }
    }
}
