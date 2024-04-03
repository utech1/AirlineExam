using Application.Features.Cities.Queries.GetList;
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

namespace Application.Features.Cities.Queries.GetList;

public class GetListCitiesQuery : IRequest<GetListResponse<GetListCitiesListItemDto>>, ICachableRequest, ILoggableRequest
{

    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListCitiesQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }

    public string? CacheGroupKey => "GetCities";

    public class GetListCitiesQueryHandler : IRequestHandler<GetListCitiesQuery, GetListResponse<GetListCitiesListItemDto>>
    {
        private readonly ICityRepository _citiesRepository;
        private readonly IMapper _mapper;

        public GetListCitiesQueryHandler(ICityRepository citiesRepository, IMapper mapper)
        {
            _citiesRepository = citiesRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCitiesListItemDto>> Handle(GetListCitiesQuery request, CancellationToken cancellationToken)
        {
            Paginate<City> cities = await _citiesRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                withDeleted: true
                );

            GetListResponse<GetListCitiesListItemDto> response = _mapper.Map<GetListResponse<GetListCitiesListItemDto>>(cities);
            return response;

        }
    }
}
