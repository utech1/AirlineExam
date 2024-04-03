using Application.Features.Countries.Queries.GetList;
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

namespace Application.Features.Countries.Queries.GetList;

public class GetListCountryQuery : IRequest<GetListResponse<GetListCountryListItemDto>>, ICachableRequest, ILoggableRequest
{

    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListCountryQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }

    public string? CacheGroupKey => "GetCountries";

    public class GetListCountryQueryHandler : IRequestHandler<GetListCountryQuery, GetListResponse<GetListCountryListItemDto>>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetListCountryQueryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCountryListItemDto>> Handle(GetListCountryQuery request, CancellationToken cancellationToken)
        {
            Paginate<Country> countries = await _countryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                withDeleted: true
                );

            GetListResponse<GetListCountryListItemDto> response = _mapper.Map<GetListResponse<GetListCountryListItemDto>>(countries);
            return response;

        }
    }
}
