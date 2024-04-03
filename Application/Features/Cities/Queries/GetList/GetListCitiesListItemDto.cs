using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries.GetList;

public class GetListCitiesListItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CountryId { get; set; }

    public int Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
