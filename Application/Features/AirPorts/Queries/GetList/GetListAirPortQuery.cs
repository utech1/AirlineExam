using Application.Features.AirPorts.Queries.GetList;
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

namespace Application.Features.AirPorts.Queries.GetList;

public class GetListAirPortQuery : IRequest<GetListResponse<GetListAirPortListItemDto>>, ICachableRequest, ILoggableRequest
{

    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListAirPortQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }

    public string? CacheGroupKey => "GetAirPorts";

    public class GetListAirPortQueryHandler : IRequestHandler<GetListAirPortQuery, GetListResponse<GetListAirPortListItemDto>>
    {
        private readonly IAirPortRepository _AirPortRepository;
        private readonly IMapper _mapper;

        public GetListAirPortQueryHandler(IAirPortRepository AirPortRepository, IMapper mapper)
        {
            _AirPortRepository = AirPortRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAirPortListItemDto>> Handle(GetListAirPortQuery request, CancellationToken cancellationToken)
        {
            Paginate<AirPort> AirPorts = await _AirPortRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                withDeleted: true
                );

            GetListResponse<GetListAirPortListItemDto> response = _mapper.Map<GetListResponse<GetListAirPortListItemDto>>(AirPorts);
            return response;

        }
    }
}
