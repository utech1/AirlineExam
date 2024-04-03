using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class AirPort:Entity<Guid>
{
    public string Name { get; set; }
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }


    public int Status { get; set; }
    
    public AirPort()
    {
        
    }
    public AirPort(string _name,Guid _countryId, Guid _cityId,int _status) : this()
    {
        Name = _name; 
        CountryId= _countryId;
        CityId= _cityId;

        Status = _status;
   
            

    }
}
