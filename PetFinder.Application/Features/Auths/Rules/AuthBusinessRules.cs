﻿using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using PetFinder.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task EmailCanNotBeDuplicatedWhenInserted(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("There is such an email in the system.");
        }
        public async Task AuthLoginEmailCheck(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user == null) throw new BusinessException("Such an email was not found in the system.");
        }
    }
}
