using AutoMapper;
using MediatR;
using PetFinder.Application.Features.ContactInformations.Dtos;
using PetFinder.Application.Services.Repositories;
using PetFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace PetFinder.Application.Features.ContactInformations.Queries.GetByIdContactInformation
{
    public class GetByIdContactInformationQuery:IRequest<ContactInformationGetByIdDto>
    {
        public int Id { get; set; }
    }

    public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdContactInformationQuery, ContactInformationGetByIdDto>
    {
        private readonly IContactInformationRepository _contactInformationRepository;
        private readonly IMapper _mapper;

        public GetByIdBrandQueryHandler(IContactInformationRepository contactInformationRepository, IMapper mapper)
        {
            _contactInformationRepository = contactInformationRepository;
            _mapper = mapper;
        }

        public async Task<ContactInformationGetByIdDto> Handle(GetByIdContactInformationQuery request, CancellationToken cancellationToken)
        {
            ContactInformation? contactInformation = await _contactInformationRepository.GetAsync(b => b.Id == request.Id);

            ContactInformationGetByIdDto contactInformationGetByIdDto = _mapper.Map<ContactInformationGetByIdDto>(contactInformation);
            return contactInformationGetByIdDto;
        }
    }
}
