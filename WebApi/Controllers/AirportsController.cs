using Application.Features.AirPorts.Commands.Create;

using Application.Features.AirPorts.Commands.Update;

using Application.Features.AirPorts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirPortsController : BaseController
    {
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAirPortCommand createAirPortCommand)
        {
            CreatedAirPortResponse response = await Mediator.Send(createAirPortCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListAirPortQuery getListAirPortQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListAirPortListItemDto> response = await Mediator.Send(getListAirPortQuery);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAirPortCommand updateAirPortCommand)
        {
            UpdatedAirPortResponse response = await Mediator.Send(updateAirPortCommand);

            return Ok(response);
        }

        
    }
}
