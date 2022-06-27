using HRMS.Business.Queries.Inputs;
using HRMS.Business.Queries.Results;
using HRMS.Comman.ApiResponse;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("GetCountries", Name = "GetCountries")]
        public async Task<ActionResult<DataResponse<List<GetCountryListQueryResult>>>> GetCountries()
        {
            var commanResult = await _mediator.Send(new GetCountryListQuery());
            if (commanResult == null || commanResult.Messages != null)
                return BadRequest(new Response(StatusCodes.Status400BadRequest, "Invalid data", commanResult.Messages));
            return Ok(new DataResponse<List<GetCountryListQueryResult>>(StatusCodes.Status200OK, commanResult.Result));
        }

        [AllowAnonymous]
        [HttpGet("GetStates/{countryId}", Name = "GetStates")]
        public async Task<ActionResult<DataResponse<List<GetStateListByCountryIdQueryResult>>>> GetStates(int countryId)
        {
            var commanResult = await _mediator.Send(new GetStateListByCountryIdQuery(countryId));
            if (commanResult == null || commanResult.Messages != null)
                return BadRequest(new Response(StatusCodes.Status400BadRequest, "Invalid data", commanResult.Messages));
            return Ok(new DataResponse<List<GetStateListByCountryIdQueryResult>>(StatusCodes.Status200OK, commanResult.Result));
        }

    }
}
