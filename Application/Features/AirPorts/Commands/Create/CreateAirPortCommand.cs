using Application.Features.AirPorts.Rules;

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

namespace Application.Features.AirPorts.Commands.Create;

public class CreateAirPortCommand:IRequest<CreatedAirPortResponse>,ITransactionalRequest,ICacheRemoverRequest,ILoggableRequest
{
    public string Name { get; set; }
    public string CountryId { get; set; }
    public string CityId { get; set; }


    public int Status { get; set; }
    public int AirPortStatus { get; set; } = 1;
    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetAirPorts";

   public class CreateAirPortCommandHandler : IRequestHandler<CreateAirPortCommand, CreatedAirPortResponse>
    {
        private readonly IAirPortRepository _AirPortsRepository;
        private readonly IMapper _mapper;
        private readonly AirPortBusinessRules _AirPortBusinessRules;

        public CreateAirPortCommandHandler(IAirPortRepository AirPortRepository, IMapper mapper, AirPortBusinessRules AirPortBusinessRules)
        {
            _AirPortsRepository = AirPortRepository;
            _mapper = mapper;
            _AirPortBusinessRules = AirPortBusinessRules;
        }

        public async Task<CreatedAirPortResponse>? Handle(CreateAirPortCommand request, CancellationToken cancellationToken)
        {

            await _AirPortBusinessRules.AirPortNameCannotBeDuplicatedWhenInserted(request.Name);

            AirPort AirPort = _mapper.Map<AirPort>(request);
            AirPort.Id = Guid.NewGuid();            

            await _AirPortsRepository.AddAsync(AirPort);          

            CreatedAirPortResponse createdBrandResponse = _mapper.Map<CreatedAirPortResponse>(AirPort);
            return createdBrandResponse;
        }
    }
}
