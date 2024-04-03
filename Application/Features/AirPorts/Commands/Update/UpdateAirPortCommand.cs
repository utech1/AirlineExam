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

namespace Application.Features.AirPorts.Commands.Update;

public class UpdateAirPortCommand : IRequest<UpdatedAirPortResponse>, ICacheRemoverRequest 
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string CountryId { get; set; }
    public string CityId { get; set; }


    public int Status { get; set; }



    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetAirPorts";

    public class UpdateAirPortCommandHandler : IRequestHandler<UpdateAirPortCommand, UpdatedAirPortResponse>
    {
        private readonly IAirPortRepository _AirPortRepository;
        private readonly IMapper _mapper;

        public UpdateAirPortCommandHandler(IAirPortRepository AirPortRepository, IMapper mapper)
        {
            _AirPortRepository = AirPortRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedAirPortResponse> Handle(UpdateAirPortCommand request, CancellationToken cancellationToken)
        {
            AirPort? AirPort = await _AirPortRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            AirPort = _mapper.Map(request, AirPort);

            await _AirPortRepository.UpdateAsync(AirPort);

            UpdatedAirPortResponse response = _mapper.Map<UpdatedAirPortResponse>(AirPort);

            return response;
        }
    }
}
