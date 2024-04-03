using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Flight:Entity<Guid>
{
    public string FlightName { get; set; }
    public Guid FromAirPortId { get; set; }
    public Guid ToAirPortId { get; set; }
    public string FlightCode { get; set; }
    public DateTime FlightDate { get; set; }
  


    public int Status { get; set; }
  
    public Flight()
    {
        
    }
    public Flight(string _flightName, Guid _fromAirPortId, Guid _toAirPortId,string _flightCode, DateTime _flightDate, int _status) : this()
    {
        FlightName = _flightName;
        FromAirPortId = _fromAirPortId;
        ToAirPortId = _toAirPortId;
        FlightCode = _flightCode;
        Status = _status;
        FlightDate = _flightDate;
   
            

    }
}
