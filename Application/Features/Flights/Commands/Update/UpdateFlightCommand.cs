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

namespace Application.Features.Flights.Commands.Update;

public class UpdateFlightCommand : IRequest<UpdatedFlightResponse>, ICacheRemoverRequest 
{
    public Guid Id { get; set; }

    public string FlightName { get; set; }
    public string FromAirPortId { get; set; }
    public string ToAirPortId { get; set; }
    public string FlightCode { get; set; }
    public DateTime FlightDate { get; set; }



    public int Status { get; set; }



    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetFlights";

    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand, UpdatedFlightResponse>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public UpdateFlightCommandHandler(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedFlightResponse> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            Flight? Flight = await _flightRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            Flight = _mapper.Map(request, Flight);

            await _flightRepository.UpdateAsync(Flight);

            UpdatedFlightResponse response = _mapper.Map<UpdatedFlightResponse>(Flight);

            return response;
        }
    }
}
