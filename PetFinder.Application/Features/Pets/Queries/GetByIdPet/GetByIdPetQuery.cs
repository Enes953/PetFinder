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
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace PetFinder.Application.Features.Pets.Queries.GetByIdPet
{
    public class GetByIdPetQuery:IRequest<PetGetByIdDto>
    {
        public int Id { get; set; }
    }
    public class GetByIdPetQueryHandler : IRequestHandler<GetByIdPetQuery, PetGetByIdDto>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public GetByIdPetQueryHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<PetGetByIdDto> Handle(GetByIdPetQuery request, CancellationToken cancellationToken)
        {
            Pet? pet = await _petRepository.GetAsync(b => b.Id == request.Id);

           PetGetByIdDto petGetByIdDto = _mapper.Map<PetGetByIdDto>(pet);
            return petGetByIdDto;
        }
    }
}
