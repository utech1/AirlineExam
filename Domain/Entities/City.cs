using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class City:Entity<Guid>
{
    public string Name { get; set; }
    public Guid CountryId { get; set; }

    public int Status { get; set; }

  
    
    public City()
    {
   
    }
    public City(string _name, Guid _countryId,int _status) : this()
    {
      Name = _name;
        CountryId = _countryId;
        Status = _status;
   
            

    }
}
