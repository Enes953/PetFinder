using AutoMapper;
using MediatR;
using PetFinder.Application.Features.Locations.Dtos;
using PetFinder.Application.Services.Repositories;
using PetFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace PetFinder.Application.Features.Locations.Queries.GetByIdLocation
{
    public class GetByIdLocationQuery:IRequest<LocationGetByIdDto>
    {
        public int Id { get; set; }
    }

    public class GetByIdLocationQueryHandler : IRequestHandler<GetByIdLocationQuery, LocationGetByIdDto>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;

        public GetByIdLocationQueryHandler(IMapper mapper, ILocationRepository locationRepository)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
        }

        public async Task<LocationGetByIdDto> Handle(GetByIdLocationQuery request, CancellationToken cancellationToken)
        {
            Location? location = await _locationRepository.GetAsync(b => b.Id == request.Id);

            LocationGetByIdDto locationGetByIdDto = _mapper.Map<LocationGetByIdDto>(location);
            return locationGetByIdDto;
        }
    }
}
