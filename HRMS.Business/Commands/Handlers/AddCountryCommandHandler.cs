using AutoMapper;
using HRMS.Business.Commands.Inputs;
using HRMS.EFDb.Domain;
using HRMS.EFDb.UnitsOfWork;
using MediatR;

namespace HRMS.Business.Commands.Handlers;
public class AddCountryCommandHandler : IRequestHandler<AddCountryCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public AddCountryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<bool> Handle(AddCountryCommand request, CancellationToken cancellationToken)
    {
        Country country = await _unitOfWork.Country.FirstOrDefaultAsync(x => x.Code == request.Model.Code);
        if (country != null)
        {
            return false;
        }
        country = _mapper.Map<Country>(request.Model);
        _unitOfWork.Country.Add(country);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
