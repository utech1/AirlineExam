using Application.Features.Cities.Rules;

using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Commands.Create;

public class CreateCitiesCommand : IRequest<CreatedCitiesResponse>,ITransactionalRequest,ICacheRemoverRequest,ILoggableRequest
{
    public string Name { get; set; }
    public string CountryId { get; set; }

    public int Status { get; set; }
    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetCitiess";

   public class CreateCitiesCommandHandler : IRequestHandler<CreateCitiesCommand, CreatedCitiesResponse>
    {
        private readonly ICityRepository _citiessRepository;
        private readonly IMapper _mapper;
        private readonly CitiesBusinessRules _citiesBusinessRules;

        public CreateCitiesCommandHandler(ICityRepository citiesRepository, IMapper mapper, CitiesBusinessRules citiesBusinessRules)
        {
            _citiessRepository = citiesRepository;
            _mapper = mapper;
            _citiesBusinessRules = citiesBusinessRules;
        }

        public async Task<CreatedCitiesResponse>? Handle(CreateCitiesCommand request, CancellationToken cancellationToken)
        {

            await _citiesBusinessRules.CityNameCannotBeDuplicatedWhenInserted(request.Name);

            City cities = _mapper.Map<City>(request);
            cities.Id = Guid.NewGuid();            

            await _citiessRepository.AddAsync(cities);          

            CreatedCitiesResponse createdBrandResponse = _mapper.Map<CreatedCitiesResponse>(cities);
            return createdBrandResponse;
        }
    }
}
