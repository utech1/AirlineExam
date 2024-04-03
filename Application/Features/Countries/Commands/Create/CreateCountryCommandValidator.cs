using Application.Features.Countries.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FeaturesCountries.Commands.Create;

public class CreateCountrCommandValidator:AbstractValidator<CreateCountryCommand>
{
    public CreateCountrCommandValidator()
    {
        RuleFor(c => c.LongName).NotEmpty().MinimumLength(2);
       
    }
}
