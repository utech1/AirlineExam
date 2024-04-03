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

namespace Application.Features.Cities.Commands.Update;

public class UpdateCitiesCommand : IRequest<UpdatedCitiesResponse>, ICacheRemoverRequest 
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string CountryId { get; set; }

    public int Status { get; set; }



    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetCities";

    public class UpdateCitiesCommandHandler : IRequestHandler<UpdateCitiesCommand, UpdatedCitiesResponse>
    {
        private readonly ICityRepository _citiesRepository;
        private readonly IMapper _mapper;

        public UpdateCitiesCommandHandler(ICityRepository citiesRepository, IMapper mapper)
        {
            _citiesRepository = citiesRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedCitiesResponse> Handle(UpdateCitiesCommand request, CancellationToken cancellationToken)
        {
            City? cities = await _citiesRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            cities = _mapper.Map(request, cities);

            await _citiesRepository.UpdateAsync(cities);

            UpdatedCitiesResponse response = _mapper.Map<UpdatedCitiesResponse>(cities);

            return response;
        }
    }
}
