using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AirPorts.Queries.GetList;

public class GetListAirPortListItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CountryId { get; set; }
    public string CityId { get; set; }


    public int Status { get; set; }
}
