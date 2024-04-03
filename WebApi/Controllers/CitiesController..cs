using Application.Features.Cities.Commands.Create;

using Application.Features.Cities.Commands.Update;

using Application.Features.Cities.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : BaseController
    {
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCitiesCommand createCitiesCommand)
        {
            CreatedCitiesResponse response = await Mediator.Send(createCitiesCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCitiesQuery getListCitiesQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListCitiesListItemDto> response = await Mediator.Send(getListCitiesQuery);
            return Ok(response);
        }

        

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCitiesCommand updateCitiesCommand)
        {
            UpdatedCitiesResponse response = await Mediator.Send(updateCitiesCommand);

            return Ok(response);
        }

        
    }
}
