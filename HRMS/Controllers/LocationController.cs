using HRMS.Business.Commands.Inputs;
using HRMS.Business.Queries.Inputs;
using HRMS.Business.Queries.Results;
using HRMS.Comman.ApiResponse;
using HRMS.Comman.RequestModels.Location;
using HRMS.Comman.RequestModelValidators.Location;
using HRMS.Comman.Utility;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers;

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
    public async Task<ActionResult<DataResponse<List<GetStateListByCountryIdQueryResult>>>> GetStates([FromRoute] int countryId)
    {
        var commanResult = await _mediator.Send(new GetStateListByCountryIdQuery(countryId));
        if (commanResult == null || commanResult.Messages != null)
            return BadRequest(new Response(StatusCodes.Status400BadRequest, "Invalid data", commanResult.Messages));
        return Ok(new DataResponse<List<GetStateListByCountryIdQueryResult>>(StatusCodes.Status200OK, commanResult.Result));
    }

    [AllowAnonymous]
    [HttpPost("addCountry", Name = "addCountry")]
    public async Task<ActionResult<Response>> AddCountry([FromBody] AddCountryRequestModel model)
    {
        var validator = new AddCountryRequestModelValidator();
        var result = await validator.ValidateAsync(model);
        if (!result.IsValid)
        {
            var errors = CommanUtility.GetFluentValidationErrorMessages(result.Errors);
            return BadRequest(new Response(StatusCodes.Status400BadRequest, "Validation Error", errors));
        }

        var commanResult = await _mediator.Send(new AddCountryCommand(model));
        if (!commanResult)
            return StatusCode(StatusCodes.Status208AlreadyReported, new Response(StatusCodes.Status208AlreadyReported, $"{model.Name} is already added"));

        return Ok(new Response(StatusCodes.Status201Created, $"{model.Name} added successfully"));
    }

}
