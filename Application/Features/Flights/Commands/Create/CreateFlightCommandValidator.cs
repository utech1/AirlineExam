using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Flights.Commands.Create;

public class CreateFlightCommandValidator:AbstractValidator<CreateFlightCommand>
{
    public CreateFlightCommandValidator()
    {
        RuleFor(c => c.FlightCode).NotEmpty().MinimumLength(2);
        //RuleFor(c => c.FlightName).NotEmpty().MinimumLength(2);

    }
}
