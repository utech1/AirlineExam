using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class SalesFlight:Entity<Guid>
{
    public string CustomerName { get; set; }
    public DateTime SalesDate { get; set; }
    public string PassportNumber { get; set; }
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid FlightId { get; set; }



    public int Status { get; set; }
    public virtual Country? Countries { get; set; }
    public virtual City? Cities { get; set; }
    public virtual Flight? Flights { get; set; }

    public SalesFlight()
    {
        
    }
    public SalesFlight(string _customerName, DateTime _salesDate, string _passportNumber, Guid _countryId, Guid _cityId, Guid _flightId, int _status) : this()
    {
       
        CustomerName = _customerName;
        SalesDate = _salesDate;
        PassportNumber = _passportNumber;
        CountryId = _countryId;
        CityId = _cityId;
        FlightId = _flightId;

        Status = _status;
      
            

    }
}
