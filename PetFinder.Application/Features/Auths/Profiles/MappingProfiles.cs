using AutoMapper;
using Core.Security.Entities;
using PetFinder.Application.Features.Auths.Commands.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Application.Features.Auths.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, RegisterCommand>().ReverseMap();
            CreateMap<User, LoginCommand>().ReverseMap();
        }
    }
}
