using Application.Features.Flights.Commands.Create;

using Application.Features.Flights.Commands.Update;

using Application.Features.Flights.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : BaseController
    {
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFlightCommand createFlightCommand)
        {
            CreatedFlightResponse response = await Mediator.Send(createFlightCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListFlightQuery getListFlightQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListFlightListItemDto> response = await Mediator.Send(getListFlightQuery);
            return Ok(response);
        }

        

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFlightCommand updateFlightCommand)
        {
            UpdatedFlightResponse response = await Mediator.Send(updateFlightCommand);

            return Ok(response);
        }

        
    }
}
