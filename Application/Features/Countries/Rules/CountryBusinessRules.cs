using Application.Features.Countries.Constants;

using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Rules;

public class CountryBusinessRules : BaseBusinessRules
{
    private readonly ICountryRepository _countryRepository;

    public CountryBusinessRules(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task CountryNameCannotBeDuplicatedWhenInserted(string name)
    {
        Country? result = await _countryRepository.GetAsync(predicate: b=>b.LongName.ToLower()==name.ToLower());

        if (result!=null)
        {
            throw new BusinessException(CountriesMessages.CountriesNameExists);
        }
    }
}
