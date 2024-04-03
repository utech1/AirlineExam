using Application.Features.AirPorts.Constants;

using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AirPorts.Rules;

public class AirPortBusinessRules:BaseBusinessRules
{
    private readonly IAirPortRepository _AirPortRepository;

    public AirPortBusinessRules(IAirPortRepository AirPortRepository)
    {
        _AirPortRepository = AirPortRepository;
    }

    public async Task AirPortNameCannotBeDuplicatedWhenInserted(string name)
    {
        AirPort? result = await _AirPortRepository.GetAsync(predicate: b=>b.Name.ToLower()==name.ToLower());

        if (result!=null)
        {
            throw new BusinessException(AirPortsMessages.AirPortsNameExists);
        }
    }
}
