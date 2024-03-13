using AutoMapper;
using Core.Persistence.Paging;
using PetFinder.Application.Features.Locations.Commands.CreateLocation;
using PetFinder.Application.Features.Locations.Dtos;
using PetFinder.Application.Features.Locations.Models;
using PetFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace PetFinder.Application.Features.Locations.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Location, CreatedLocationDto>().ReverseMap();
            CreateMap<Location, CreateLocationCommand>().ReverseMap();

            CreateMap<IPaginate<Location>, LocationListModel>().ReverseMap();
            CreateMap<Location, LocationListDto>().ReverseMap();
            CreateMap<Location, LocationGetByIdDto>().ReverseMap();
        }
    }
}
