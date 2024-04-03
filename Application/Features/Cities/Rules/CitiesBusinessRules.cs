using Application.Features.Cities.Constants;

using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Rules;

public class CitiesBusinessRules:BaseBusinessRules
{
    private readonly ICityRepository _citiesRepository;

    public CitiesBusinessRules(ICityRepository citiesRepository)
    {
        _citiesRepository = citiesRepository;
    }

    public async Task CityNameCannotBeDuplicatedWhenInserted(string name)
    {
        City? result = await _citiesRepository.GetAsync(predicate: b=>b.Name.ToLower()==name.ToLower());

        if (result!=null)
        {
            throw new BusinessException(CitiesMessages.CitiesNameExists);
        }
    }
}
