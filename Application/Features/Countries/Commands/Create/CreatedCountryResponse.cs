using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Commands.Create;

public class CreatedCountryResponse
{
    public Guid Id { get; set; }
    public string LongName { get; set; }
    public string? ShortName { get; set; }

    public int Status { get; set; }

    public DateTime CreatedDate { get; set; }
   
}
