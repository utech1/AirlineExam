using Application.Features.SalesFlights.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SalesFlights.Queries.GetListByDynamic;

public class GetListByDynamicSalesFlightQuery : IRequest<GetListResponse<GetListByDynamicSalesFlightListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicSalesFlightQueryHandler : IRequestHandler<GetListByDynamicSalesFlightQuery, GetListResponse<GetListByDynamicSalesFlightListItemDto>>
    {
        private readonly ISalesFlightRepository _salesFlightRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicSalesFlightQueryHandler(ISalesFlightRepository salesFlightRepository, IMapper mapper)
        {
            _salesFlightRepository = salesFlightRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListByDynamicSalesFlightListItemDto>> Handle(GetListByDynamicSalesFlightQuery request, CancellationToken cancellationToken)
        {
            Paginate<SalesFlight> SalesFlights = await _salesFlightRepository.GetListByDynamicAsync(
                 request.DynamicQuery,
                 include: m => m.Include(m => m.Countries).Include(m => m.Cities).Include(m => m.Flights),
                 index: request.PageRequest.PageIndex,
                 size: request.PageRequest.PageSize
                 );

            var response = _mapper.Map<GetListResponse<GetListByDynamicSalesFlightListItemDto>>(SalesFlights);

            return response;


        }
    }
}
