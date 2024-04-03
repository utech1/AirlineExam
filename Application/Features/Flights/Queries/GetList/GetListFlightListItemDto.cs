using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Flights.Queries.GetList;

public class GetListFlightListItemDto
{
    public Guid Id { get; set; }
    public string FlightName { get; set; }
    public string FromAirPortId { get; set; }
    public string ToAirPortId { get; set; }
    public string FlightCode { get; set; }
    public DateTime FlightDate { get; set; }



    public int Status { get; set; }
}
