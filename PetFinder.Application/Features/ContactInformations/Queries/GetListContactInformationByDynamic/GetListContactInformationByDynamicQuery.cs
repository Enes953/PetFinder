using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using PetFinder.Application.Features.ContactInformations.Models;
using PetFinder.Application.Services.Repositories;
using PetFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Application.Features.ContactInformations.Queries.GetListContactInformationByDynamic
{
    public class GetListContactInformationByDynamicQuery : IRequest<ContactInformationListModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic  Dynamic { get; set; }
    }
    public class GetListContactInformationByDynamicQueryHandler : IRequestHandler<GetListContactInformationByDynamicQuery, ContactInformationListModel>
    {
        private readonly IMapper _mapper;
        private readonly IContactInformationRepository _contactInformationRepository;

        public GetListContactInformationByDynamicQueryHandler(IMapper mapper, IContactInformationRepository contactInformationRepository)
        {
            _mapper = mapper;
            _contactInformationRepository = contactInformationRepository;
        }

        public async Task<ContactInformationListModel> Handle(GetListContactInformationByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ContactInformation> contactInformations = await _contactInformationRepository.GetListByDynamicAsync(request.Dynamic,
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize);
            ContactInformationListModel mappedContactInformationListModel = _mapper.Map<ContactInformationListModel>(contactInformations);

            return mappedContactInformationListModel;
        }
    }
}
