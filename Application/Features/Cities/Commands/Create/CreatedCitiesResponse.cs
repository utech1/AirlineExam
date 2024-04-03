using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Commands.Create;

public class CreatedCitiesResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CountryId { get; set; }

    public int Status { get; set; }

    public DateTime CreatedDate { get; set; }
}
   
