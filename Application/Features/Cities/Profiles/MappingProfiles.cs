using Application.Features.Cities.Commands.Create;

using Application.Features.Cities.Commands.Update;

using Application.Features.Cities.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FeaturesCities.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<City, CreateCitiesCommand>().ReverseMap();
        CreateMap<City, CreatedCitiesResponse>().ReverseMap();

        CreateMap<City, UpdateCitiesCommand>().ReverseMap();
        CreateMap<City, UpdatedCitiesResponse>().ReverseMap();

        //CreateMap<City, DeleteCityCommand>().ReverseMap();
        //CreateMap<City, DeletedCityResponse>().ReverseMap();

        CreateMap<City, GetListCitiesListItemDto>().ReverseMap();
        CreateMap<Paginate<City>, GetListResponse<GetListCitiesListItemDto>>().ReverseMap();
    }
}
