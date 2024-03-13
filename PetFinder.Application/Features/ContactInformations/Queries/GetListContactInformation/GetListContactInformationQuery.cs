using AutoMapper;
using Core.Application.Requests;
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
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace PetFinder.Application.Features.ContactInformations.Queries.GetListContactInformation
{
    public class GetListContactInformationQuery:IRequest<ContactInformationListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
    public class GetListContactInformationQueryHandler : IRequestHandler<GetListContactInformationQuery, ContactInformationListModel>
    {
        private readonly IMapper _mapper;
        private readonly IContactInformationRepository _contactInformationRepository;

        public GetListContactInformationQueryHandler(IMapper mapper, IContactInformationRepository contactInformationRepository)
        {
            _mapper = mapper;
            _contactInformationRepository = contactInformationRepository;
        }

        public async Task<ContactInformationListModel> Handle(GetListContactInformationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ContactInformation> contactInformations = await _contactInformationRepository.GetListAsync(
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize);
            ContactInformationListModel mappedContactInformationListModel = _mapper.Map<ContactInformationListModel>(contactInformations);

            return mappedContactInformationListModel;
        }
    }
}
