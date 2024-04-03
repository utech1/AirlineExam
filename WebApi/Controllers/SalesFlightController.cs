




using Application.Features.SalesFlights.Queries.GetList;
using Application.Features.SalesFlights.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesFlightController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSalesFlightQuery getListSalesFlightQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListSalesFlightListItemDto> response = await Mediator.Send(getListSalesFlightQuery);
            return Ok(response);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery = null)
        {
            GetListByDynamicSalesFlightQuery getListByDynamicSalesFlightQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
            GetListResponse<GetListByDynamicSalesFlightListItemDto> response = await Mediator.Send(getListByDynamicSalesFlightQuery);
            return Ok(response);
        }


    }
}
