using Application.Features.Flights.Commands.Create;
using Application.Features.Flights.Commands.Update;
using Application.Features.Flights.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Flights.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Flight, CreateFlightCommand>().ReverseMap();
        CreateMap<Flight, CreatedFlightResponse>().ReverseMap();

        CreateMap<Flight, UpdateFlightCommand>().ReverseMap();
        CreateMap<Flight, UpdatedFlightResponse>().ReverseMap();


        CreateMap<Flight, GetListFlightListItemDto>().ReverseMap();
       
        CreateMap<Paginate<Flight>, GetListResponse<GetListFlightListItemDto>>().ReverseMap();
    }
}
