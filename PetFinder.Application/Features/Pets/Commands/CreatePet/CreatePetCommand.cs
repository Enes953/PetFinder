using AutoMapper;
using MediatR;
using PetFinder.Application.Features.Pets.Dtos;
using PetFinder.Application.Services.Repositories;
using PetFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Application.Features.Pets.Commands.CreatePet
{
    public class CreatePetCommand:IRequest<CreatedPetDto>
    {
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string RewardInformation { get; set; }
        public int LocationId { get; set; }
        public int ContactInformationId { get; set; }
    }
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, CreatedPetDto>
    {
        private readonly IPetRepository _petrepository;
        private readonly IMapper _mapper;

        public CreatePetCommandHandler(IPetRepository petrepository, IMapper mapper)
        {
            _petrepository = petrepository;
            _mapper = mapper;
        }

        public async Task<CreatedPetDto> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            Pet mappedPet = _mapper.Map<Pet>(request);
            Pet createPet = await _petrepository.AddAsync(mappedPet);
            CreatedPetDto createdPetDto = _mapper.Map<CreatedPetDto>(createPet);

            return createdPetDto;
        }
    }
}
