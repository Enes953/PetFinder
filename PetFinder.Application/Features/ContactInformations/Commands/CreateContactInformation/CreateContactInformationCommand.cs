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

namespace PetFinder.Application.Features.ContactInformations.Commands.CreateContactInformation
{
    public class CreateContactInformationCommand:IRequest<CreatedContactInformationDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public class CreateContactInformationCommandHandler : IRequestHandler<CreateContactInformationCommand, CreatedContactInformationDto>
        {
            private readonly IContactInformationRepository _contactInformationRepository;
            private readonly IMapper _mapper;

            public CreateContactInformationCommandHandler(IContactInformationRepository contactInformationRepository, IMapper mapper)
            {
                _contactInformationRepository = contactInformationRepository;
                _mapper = mapper;
            }

            public async Task<CreatedContactInformationDto> Handle(CreateContactInformationCommand request, CancellationToken cancellationToken)
            {
                ContactInformation mappedContactInformation = _mapper.Map<ContactInformation>(request);
                ContactInformation createContactInformation = await _contactInformationRepository.AddAsync(mappedContactInformation);
                CreatedContactInformationDto createdContactInformationDto = _mapper.Map<CreatedContactInformationDto>(createContactInformation);

                return createdContactInformationDto;
            }
        }
    }
}
