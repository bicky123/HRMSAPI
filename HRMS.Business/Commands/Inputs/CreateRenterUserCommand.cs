using HRMS.Comman.RequestModels.Account;
using MediatR;

namespace HRMS.Business.Commands.Inputs
{
    public record CreateRenterUserCommand(RenterRegistrationRequestModel Model) : IRequest<string>;
}
