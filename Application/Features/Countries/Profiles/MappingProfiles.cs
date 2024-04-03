using Application.Features.Countries.Commands.Create;
//using Application.Features.Books.Commands.Delete;
using Application.Features.Countries.Commands.Update;
//using Application.Features.Books.Queries.GetById;
using Application.Features.Countries.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Country, CreateCountryCommand>().ReverseMap();
        CreateMap<Country, CreatedCountryResponse>().ReverseMap();

        CreateMap<Country, UpdateCountryCommand>().ReverseMap();
        CreateMap<Country, UpdatedCountryResponse>().ReverseMap();

        ////CreateMap<Country, DeleteCountryCommand>().ReverseMap();
        ////CreateMap<Country, DeletedCountryResponse>().ReverseMap();

        CreateMap<Country, GetListCountryListItemDto>().ReverseMap();    
        CreateMap<Paginate<Country>, GetListResponse<GetListCountryListItemDto>>().ReverseMap();
    }
}
