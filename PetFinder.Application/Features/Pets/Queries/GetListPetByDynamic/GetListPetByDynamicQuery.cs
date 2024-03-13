using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
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

namespace PetFinder.Application.Features.Pets.Queries.GetListPetByDynamic
{
    public class GetListPetByDynamicQuery : IRequest<PetListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
    }

    public class GetListPetByDynamicQueryHandler : IRequestHandler<GetListPetByDynamicQuery, PetListModel>
    {
        private readonly IMapper _mapper;
        private readonly IPetRepository _petRepository;

        public GetListPetByDynamicQueryHandler(IMapper mapper, IPetRepository petRepository)
        {
            _mapper = mapper;
            _petRepository = petRepository;
        }

        public async Task<PetListModel> Handle(GetListPetByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Pet> pets = await _petRepository.GetListByDynamicAsync(request.Dynamic,
                                               index: request.PageRequest.Page,
                                               size: request.PageRequest.PageSize);
            PetListModel mappedPetListModel = _mapper.Map<PetListModel>(pets);

            return mappedPetListModel;
        }
    }
}
