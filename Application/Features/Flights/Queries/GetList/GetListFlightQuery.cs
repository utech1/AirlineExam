using Application.Features.Flights.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Flights.Queries.GetList;

public class GetListFlightQuery : IRequest<GetListResponse<GetListFlightListItemDto>>, ICachableRequest, ILoggableRequest
{

    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListFlightQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }

    public string? CacheGroupKey => "GetFlights";

    public class GetListFlightQueryHandler : IRequestHandler<GetListFlightQuery, GetListResponse<GetListFlightListItemDto>>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public GetListFlightQueryHandler(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFlightListItemDto>> Handle(GetListFlightQuery request, CancellationToken cancellationToken)
        {
            Paginate<Flight> flights = await _flightRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                withDeleted: true
                );

            GetListResponse<GetListFlightListItemDto> response = _mapper.Map<GetListResponse<GetListFlightListItemDto>>(flights);
            return response;

        }
    }
}
