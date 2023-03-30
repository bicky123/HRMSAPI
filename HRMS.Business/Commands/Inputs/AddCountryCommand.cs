using HRMS.Comman.RequestModels.Location;
using MediatR;

namespace HRMS.Business.Commands.Inputs;
public record AddCountryCommand(AddCountryRequestModel Model) : IRequest<bool>;

