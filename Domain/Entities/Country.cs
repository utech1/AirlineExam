using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Country:Entity<Guid>
{
    public string LongName { get; set; }
    public string? ShortName { get; set; }

    public int Status { get; set; }


  

    public Country()
    {
       
    }
    public Country(string _lonngName,string _shortName,int _status) : this()
    {
        LongName = _lonngName;
        ShortName = _shortName;
        Status = _status;
   
            

    }
}
