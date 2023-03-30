using AutoMapper;
using HRMS.Comman.RequestModels.Location;
using HRMS.EFDb.Domain;

namespace HRMS.Business.Commands;
public class CommandMapperProfile : Profile
{
    public CommandMapperProfile()
    {
        CreateMap<AddCountryRequestModel, Country>().ReverseMap();
    }
}
