using Application.Features.Flights.Constants;

using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Flights.Rules;

public class FlightBusinessRules:BaseBusinessRules
{
    private readonly IFlightRepository _flightRepository;

    public FlightBusinessRules(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task FlightNameCannotBeDuplicatedWhenInserted(string name)
    {
        Flight? result = await _flightRepository.GetAsync(predicate: b=>b.FlightName.ToLower()==name.ToLower());

        if (result!=null)
        {
            throw new BusinessException(FlightsMessages.FlightsNameExists);
        }
    }
}
