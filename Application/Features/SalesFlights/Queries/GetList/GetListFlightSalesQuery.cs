using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SalesFlights.Queries.GetList;

public class GetListSalesFlightQuery:IRequest<GetListResponse<GetListSalesFlightListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSalesFlightQueryHandler : IRequestHandler<GetListSalesFlightQuery, GetListResponse<GetListSalesFlightListItemDto>>
    {
        private readonly ISalesFlightRepository _SalesFlightRepository;
        private readonly IMapper _mapper;

        public GetListSalesFlightQueryHandler(ISalesFlightRepository SalesFlightRepository, IMapper mapper)
        {
            _SalesFlightRepository = SalesFlightRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListSalesFlightListItemDto>> Handle(GetListSalesFlightQuery request, CancellationToken cancellationToken)
        {
           Paginate<SalesFlight> SalesFlights =  await _SalesFlightRepository.GetListAsync(
                include: m => m.Include(m=>m.Countries).Include(m=>m.Cities).Include(m=>m.Flights),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
                );

            var response = _mapper.Map<GetListResponse<GetListSalesFlightListItemDto>>(SalesFlights);

            return response;
           

        }
    }
}
