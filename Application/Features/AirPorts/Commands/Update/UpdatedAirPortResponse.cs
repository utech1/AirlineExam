using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AirPorts.Commands.Update;

public class UpdatedAirPortResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CountryId { get; set; }
    public string CityId { get; set; }


    public int Status { get; set; }
}
