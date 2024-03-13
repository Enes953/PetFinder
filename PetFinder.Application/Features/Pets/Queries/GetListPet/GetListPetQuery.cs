using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using PetFinder.Application.Features.Pets.Models;
using PetFinder.Application.Services.Repositories;
using PetFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace PetFinder.Application.Features.Pets.Queries.GetListPet
{
    public class GetListPetQuery:IRequest<PetListModel>
    {
        public PageRequest PageRequest { get; set; }
    }

    public class GetListPetQueryHandler : IRequestHandler<GetListPetQuery, PetListModel>
    {
        private readonly IMapper _mapper;
        private readonly IPetRepository _petRepository;

        public GetListPetQueryHandler(IMapper mapper, IPetRepository petRepository)
        {
            _mapper = mapper;
            _petRepository = petRepository;
        }

        public async Task<PetListModel> Handle(GetListPetQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Pet> pets = await _petRepository.GetListAsync(
                                               index: request.PageRequest.Page,
                                               size: request.PageRequest.PageSize);
            PetListModel mappedPetListModel = _mapper.Map<PetListModel>(pets);

            return mappedPetListModel;
        }
    }
}
