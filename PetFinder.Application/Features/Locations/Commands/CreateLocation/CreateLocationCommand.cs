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

namespace PetFinder.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommand:IRequest<CreatedLocationDto>
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, CreatedLocationDto>
        {
            private readonly ILocationRepository _locationRepository;
            private readonly IMapper _mapper;

            public CreateLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
            {
                _locationRepository = locationRepository;
                _mapper = mapper;
            }

            public async Task<CreatedLocationDto> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
            {
                Location mappedLocation = _mapper.Map<Location>(request);
                Location createLocation = await _locationRepository.AddAsync(mappedLocation);
                CreatedLocationDto createdLocationDto = _mapper.Map<CreatedLocationDto>(createLocation);

                return createdLocationDto;
            }
        }
    }
}
