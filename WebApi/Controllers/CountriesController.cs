using Application.Features.Countries.Commands.Create;


using Application.Features.Countries.Commands.Update;

using Application.Features.Countries.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : BaseController
    {
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCountryCommand createCountryCommand)
        {
            CreatedCountryResponse response = await Mediator.Send(createCountryCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCountryQuery getListCountryQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListCountryListItemDto> response = await Mediator.Send(getListCountryQuery);
            return Ok(response);
        }



        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCountryCommand updateCountryCommand)
        {
            UpdatedCountryResponse response = await Mediator.Send(updateCountryCommand);

            return Ok(response);
        }


    }
}
