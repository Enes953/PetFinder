using Core.Security.Dtos;
using Core.Security.Entities;
using MediatR;
using PetFinder.Application.Features.Auths.Dtos;
using PetFinder.Application.Features.Auths.Rules;
using PetFinder.Application.Services.AuthService;
using PetFinder.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoginedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginedDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.AuthLoginEmailCheck(request.UserForLoginDto.Email);
                User? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

                var createdAccessToken = await _authService.CreateAccessToken(user);
                var createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                return new LoginedDto()
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = addedRefreshToken
                };
            }
        }
    }
}
