using Application.Features.SalesFlights.Queries.GetList;
using Application.Features.SalesFlights.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SalesFlights.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SalesFlight, GetListSalesFlightListItemDto>()
            .ForMember(destinationMember: c => c.CityName, memberOptions: opt => opt.MapFrom(c => c.Cities.Name))
            .ForMember(destinationMember: c => c.CountryName, memberOptions: opt => opt.MapFrom(c => c.Countries.LongName))
            .ForMember(destinationMember: c => c.FlightName, memberOptions: opt => opt.MapFrom(c => c.Flights.FlightName))
            .ReverseMap();
        CreateMap<SalesFlight, GetListByDynamicSalesFlightListItemDto>()
             .ForMember(destinationMember: c => c.CityName, memberOptions: opt => opt.MapFrom(c => c.Cities.Name))
            .ForMember(destinationMember: c => c.CountryName, memberOptions: opt => opt.MapFrom(c => c.Countries.LongName))
            .ForMember(destinationMember: c => c.FlightName, memberOptions: opt => opt.MapFrom(c => c.Flights.FlightName))
            .ReverseMap();
        CreateMap<Paginate<SalesFlight>, GetListResponse<GetListSalesFlightListItemDto>>().ReverseMap();
        CreateMap<Paginate<SalesFlight>, GetListResponse<GetListByDynamicSalesFlightListItemDto>>().ReverseMap();
    }
}