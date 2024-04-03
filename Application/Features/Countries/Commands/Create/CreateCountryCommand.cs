using Application.Features.Countries.Rules;

using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Commands.Create;

public class CreateCountryCommand:IRequest<CreatedCountryResponse>,ITransactionalRequest,ICacheRemoverRequest,ILoggableRequest
{
    public string LongName { get; set; }
    public string? ShortName { get; set; }

    public int Status { get; set; }
    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetBooks";

   public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CreatedCountryResponse>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly CountryBusinessRules _countryBusinessRules;

        public CreateCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper, CountryBusinessRules countryBusinessRules)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _countryBusinessRules = countryBusinessRules;
        }

        public async Task<CreatedCountryResponse>? Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {

            await _countryBusinessRules.CountryNameCannotBeDuplicatedWhenInserted(request.LongName);

            Country country = _mapper.Map<Country>(request);
            country.Id = Guid.NewGuid();            

            await _countryRepository.AddAsync(country);          

            CreatedCountryResponse createdCountryResponse = _mapper.Map<CreatedCountryResponse>(country);
            return createdCountryResponse;
        }
    }
}
