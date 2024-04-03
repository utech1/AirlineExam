using Application.Features.AirPorts.Commands.Create;
using Application.Features.AirPorts.Commands.Update;
using Application.Features.AirPorts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AirPorts.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<AirPort, CreateAirPortCommand>().ReverseMap();
        CreateMap<AirPort, CreatedAirPortResponse>().ReverseMap();

        CreateMap<AirPort, UpdateAirPortCommand>().ReverseMap();
        CreateMap<AirPort, UpdatedAirPortResponse>().ReverseMap();

        //CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
        //CreateMap<Brand, DeletedBrandResponse>().ReverseMap();

        CreateMap<AirPort, GetListAirPortListItemDto>().ReverseMap();
        //CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();
        CreateMap<Paginate<AirPort>, GetListResponse<GetListAirPortListItemDto>>().ReverseMap();
    }
}
