using AutoMapper;
using HRMS.Business.Queries.Inputs;
using HRMS.Business.Queries.Results;
using HRMS.EFDb.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRMS.Business.Queries.Handlers
{
    public class FindUserByEmailQueryHandler : IRequestHandler<FindUserByEmailQuery, CommanResult<FindUserByEmailQueryResult>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public FindUserByEmailQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<CommanResult<FindUserByEmailQueryResult>> Handle(FindUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var findUserByEmailQuery = _mapper.Map<FindUserByEmailQueryResult>(user);
            return new CommanResult<FindUserByEmailQueryResult>(findUserByEmailQuery, null);
        }
    }
}
