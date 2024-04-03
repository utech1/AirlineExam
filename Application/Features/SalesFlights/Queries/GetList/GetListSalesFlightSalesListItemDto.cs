using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SalesFlights.Queries.GetList;

public class GetListSalesFlightListItemDto
{
    public Guid Id { get; set; }
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public string FlightName { get; set; }
    public string Name { get; set; }

    public string CustomerName { get; set; }
    public DateTime SalesDate { get; set; }
    public string PassportNumber { get; set; }

}
