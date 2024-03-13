using AutoMapper;
using Core.Persistence.Paging;
using PetFinder.Application.Features.ContactInformations.Commands.CreateContactInformation;
using PetFinder.Application.Features.ContactInformations.Dtos;
using PetFinder.Application.Features.ContactInformations.Models;
using PetFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Application.Features.ContactInformations.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ContactInformation, CreatedContactInformationDto>().ReverseMap();
            CreateMap<ContactInformation, CreateContactInformationCommand>().ReverseMap();

            CreateMap<IPaginate<ContactInformation>, ContactInformationListModel>().ReverseMap();
            CreateMap<ContactInformation, ContactInformationListDto>().ReverseMap();
            CreateMap<ContactInformation, ContactInformationGetByIdDto>().ReverseMap();
        }
    }
}
