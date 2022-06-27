using HRMS.Business.Commands.Inputs;
using HRMS.Comman.Utility;
using HRMS.EFDb;
using HRMS.EFDb.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HRMS.Business.Commands.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;
        public CreateUserCommandHandler(UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = new ApplicationUser
                    {
                        Email = request.Model.Email,
                        UserName = request.Model.Email,
                        PhoneNumber = request.Model.Phone,
                        Status = StatusValue.Active,
                        CreatedOn = DateTimeOffset.Now,
                        UpdatedOn = DateTimeOffset.Now,
                        CreatedBy = request.Model.Email,
                        UpdatedBy = request.Model.Email
                    };
                    await _userManager.CreateAsync(user, request.Model.Password);

                    var roleStore = new RoleStore<IdentityRole>(_context);
                    if (!_context.Roles.Any(r => r.Name == RoleValue.Owner))
                        await roleStore.CreateAsync(new IdentityRole { Name = RoleValue.Owner.ToLower(), NormalizedName = RoleValue.Temp.ToUpper() });

                    await _userManager.AddToRolesAsync(user, new List<string> { RoleValue.Owner });
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return "";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return ex.Message.ToString();
                }
            }
        }
    }
}
