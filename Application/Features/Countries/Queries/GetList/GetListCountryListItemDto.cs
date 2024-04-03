﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Queries.GetList;

public class GetListCountryListItemDto
{
    public Guid Id { get; set; }
    public string LongName { get; set; }
    public string? ShortName { get; set; }

    public int Status { get; set; }
}
