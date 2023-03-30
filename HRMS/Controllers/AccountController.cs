using HRMS.Business.Commands.Inputs;
using HRMS.Business.Queries.Inputs;
using HRMS.Comman.ApiResponse;
using HRMS.Comman.RequestModels.Account;
using HRMS.Comman.RequestModelValidators.Account;
using HRMS.Comman.ResponseModels.Account;
using HRMS.Comman.Utility;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public AccountController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost("Register/Owner", Name = "Register/Owner")]
        public async Task<ActionResult<Response>> OwnerRegistration(OwnerRegistrationRequestModel model)
        {
            var validator = new OwnerRegistrationRequestModelValidator();
            var result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                var errors = CommanUtility.GetFluentValidationErrorMessages(result.Errors);
                return BadRequest(new Response(StatusCodes.Status400BadRequest, "Validation Error", errors));
            }

            var commanResult = await _mediator.Send(new FindUserByEmailQuery(model.Email));
            if (commanResult != null && commanResult.Result != null)
                return StatusCode(StatusCodes.Status208AlreadyReported,
                    new Response(StatusCodes.Status208AlreadyReported, "Email is already exists"));

            var res = await _mediator.Send(new CreateUserCommand(model));
            if (!string.IsNullOrWhiteSpace(res))
                return BadRequest(new Response(StatusCodes.Status400BadRequest, $"Error: {res}"));

            return Created("", new Response(StatusCodes.Status201Created, "User register successfully"));
        }

        [HttpPost("Register/Renter", Name = "Register/Renter")]
        public async Task<ActionResult<Response>> RenterRegistration(RenterRegistrationRequestModel model)
        {
            var validator = new RenterRegistrationRequestModelValidator();
            var result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                var errors = CommanUtility.GetFluentValidationErrorMessages(result.Errors);
                return BadRequest(new Response(StatusCodes.Status400BadRequest, "Validation Error", errors));
            }

            var commanResult = await _mediator.Send(new FindUserByEmailQuery(model.Email));
            if (commanResult != null && commanResult.Result != null)
                return StatusCode(StatusCodes.Status208AlreadyReported,
                    new Response(StatusCodes.Status208AlreadyReported, "Email is already exists"));

            var res = await _mediator.Send(new CreateRenterUserCommand(model));
            if (!string.IsNullOrWhiteSpace(res))
                return BadRequest(new Response(StatusCodes.Status400BadRequest, $"Error: {res}"));

            return Created("", new Response(StatusCodes.Status201Created, "User register successfully"));
        }

        [HttpPost("Login", Name = "Login")]
        public async Task<ActionResult<DataResponse<LoginResponseModel>>> Login([FromBody] LoginRequestModel model)
        {
            var validator = new LoginRequestModelValidator();
            var result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                var errors = CommanUtility.GetFluentValidationErrorMessages(result.Errors);
                return BadRequest(new Response(StatusCodes.Status400BadRequest, "Validation Error", errors));
            }

            var commanResult = await _mediator.Send(new FindUserByEmailQuery(model.Email));
            if (commanResult == null || commanResult.Result == null)
                return NotFound(new Response(StatusCodes.Status404NotFound, "Email/Password is not valid"));

            var user = commanResult.Result;
            if (user.Status != StatusValue.Active)
                return Unauthorized(new Response(StatusCodes.Status401Unauthorized, "User is not active"));

            if (!user.EmailConfirmed)
                return Unauthorized(new Response(StatusCodes.Status401Unauthorized, "Email is not confirmed"));

            if (!await _mediator.Send(new CheckUserPasswordQuery(user, model.Password)))
                return BadRequest(new Response(StatusCodes.Status400BadRequest, "Email/Password is not valid"));

            var roleResult = await _mediator.Send(new GetUserRolesQuery(user));
            if (roleResult == null || roleResult.Result == null)
                return BadRequest(new Response(StatusCodes.Status400BadRequest, "User does't have roles"));

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id),
            };

            foreach (var userRole in roleResult.Result)
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWT:ValidIssuer"),
                audience: _configuration.GetValue<string>("JWT:ValidAudience"),
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var viewModel = new LoginResponseModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };

            return Ok(new DataResponse<LoginResponseModel>(StatusCodes.Status200OK, viewModel));
        }

    }
}
