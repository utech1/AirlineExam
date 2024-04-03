using Application.Features.Flights.Rules;

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

namespace Application.Features.Flights.Commands.Create;

public class CreateFlightCommand : IRequest<CreatedFlightResponse>,ITransactionalRequest,ICacheRemoverRequest,ILoggableRequest
{
    public string FlightName { get; set; }
    public string FromAirPortId { get; set; }
    public string ToAirPortId { get; set; }
    public string FlightCode { get; set; }
    public DateTime FlightDate { get; set; }



    public int Status { get; set; }
    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetFlights";

   public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, CreatedFlightResponse>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;
        private readonly FlightBusinessRules _flightBusinessRules;

        public CreateFlightCommandHandler(IFlightRepository flightRepository, IMapper mapper, FlightBusinessRules flightBusinessRules)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
            _flightBusinessRules = flightBusinessRules;
        }

        public async Task<CreatedFlightResponse>? Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {

            await _flightBusinessRules.FlightNameCannotBeDuplicatedWhenInserted(request.FlightName);

            Flight Flight = _mapper.Map<Flight>(request);
            Flight.Id = Guid.NewGuid();            

            await _flightRepository.AddAsync(Flight);          

            CreatedFlightResponse createdBrandResponse = _mapper.Map<CreatedFlightResponse>(Flight);
            return createdBrandResponse;
        }
    }
}
