using AutoMapper;
using Core.Persistence.Paging;
using PetFinder.Application.Features.Pets.Commands.CreatePet;
using PetFinder.Application.Features.Pets.Dtos;
using PetFinder.Application.Features.Pets.Models;
using PetFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace PetFinder.Application.Features.Pets.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pet, CreatedPetDto>().ReverseMap();
            CreateMap<Pet, CreatePetCommand>().ReverseMap();

            CreateMap<IPaginate<Pet>, PetListModel>().ReverseMap();
            CreateMap<Pet, PetListDto>().ReverseMap();
            CreateMap<Pet, PetGetByIdDto>().ReverseMap();
        }
    }
}
