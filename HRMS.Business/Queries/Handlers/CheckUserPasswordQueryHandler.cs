using AutoMapper;
using HRMS.Business.Queries.Inputs;
using HRMS.EFDb.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRMS.Business.Queries.Handlers
{
    public record CheckUserPasswordQueryHandler : IRequestHandler<CheckUserPasswordQuery, bool>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public CheckUserPasswordQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CheckUserPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUser>(request.model);
            var res = await _userManager.CheckPasswordAsync(user, request.password);
            return res;
        }

    }
}
