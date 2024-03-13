using AutoMapper;
using PetFinder.Application.Features.PetImagesFile.Commands.CreatePetImage;
using PetFinder.Application.Features.PetImagesFile.Dtos;
using PetFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Application.Features.PetImagesFile.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PetImageFile, CreatePetImageCommand>().ReverseMap();
            CreateMap<PetImageFile, CreatedPetImageDto>().ReverseMap();
        }
    }
}
