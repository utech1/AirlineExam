using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AirPorts.Commands.Create;

public class CreateAirPortCommandValidator : AbstractValidator<CreateAirPortCommand>
{
    public CreateAirPortCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
       
    }
}
