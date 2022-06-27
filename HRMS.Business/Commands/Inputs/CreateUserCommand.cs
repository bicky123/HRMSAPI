using HRMS.Comman.RequestModels.Account;
using MediatR;

namespace HRMS.Business.Commands.Inputs
{
    public record CreateUserCommand(OwnerRegistrationRequestModel Model) : IRequest<string>;
}
