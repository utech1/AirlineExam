using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Commands.Update;

public class UpdateCountryCommand : IRequest<UpdatedCountryResponse>, ICacheRemoverRequest 
{
    public Guid Id { get; set; }

    public string LongName { get; set; }
    public string? ShortName { get; set; }

    public int Status { get; set; }



    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetCountries";

    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, UpdatedCountryResponse>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public UpdateCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedCountryResponse> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            Country? country = await _countryRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            country = _mapper.Map(request, country);

            await _countryRepository.UpdateAsync(country);

            UpdatedCountryResponse response = _mapper.Map<UpdatedCountryResponse>(country);

            return response;
        }
    }
}
