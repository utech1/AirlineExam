using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Commands.Create;

public class CreateCitiesCommandValidator:AbstractValidator<CreateCitiesCommand>
{
    public CreateCitiesCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
       
    }
}
