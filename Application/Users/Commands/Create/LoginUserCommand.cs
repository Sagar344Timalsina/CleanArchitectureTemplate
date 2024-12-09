using Application.Common.DTOs.User;
using Domain.Interfaces;
using MediatR;
using ServiceLayer.Wrapper;
using Shared.Utils.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Create
{
    public record LoginUserCommand(LoginUserRequestDTOs userDtos) : IRequest<IResponse<LoginUserResponseDTOs>>;

    public class LoginUserCommandHandler(IUserRepositories _userRepository, IPasswordHasher _passwordHasher,ITokenService _tokenService) : IRequestHandler<LoginUserCommand, IResponse<LoginUserResponseDTOs>>
    {


        public async Task<IResponse<LoginUserResponseDTOs>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.getUserByEmail(request.userDtos.Email);

            if (user == null || !_passwordHasher.VerifyPassword(request.userDtos.Password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryDate = DateTime.UtcNow.AddDays(7);
            await _userRepository.updateAsync(user);

           var response=new LoginUserResponseDTOs()
            {

                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = 3600
            };
            return await Response<LoginUserResponseDTOs>.SuccessAsync(response);
        }
    }
}
