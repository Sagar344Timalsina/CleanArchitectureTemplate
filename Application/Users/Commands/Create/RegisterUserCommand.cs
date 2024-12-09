using Application.Common.DTOs.User;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using ServiceLayer.Wrapper;
using Shared.Utils.Wrapper;

namespace Application.Users.Commands.Create
{
    public record RegisterUserCommand(RegisterUserRequestDTOs RequestDTOs) : IRequest<IResponse>;

    public class RegisterUserCommandHandler(IUserRepositories userRepositories,IPasswordHasher _passwordHasher,ITokenService _tokenService) : IRequestHandler<RegisterUserCommand, IResponse>
    {
        public async Task<IResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordHasher.HashPassword(request.RequestDTOs.Password);
            var RefreshToken = _tokenService.GenerateRefreshToken();
            User user = new()
            {
                UserName = request.RequestDTOs.UserName,
                Email = request.RequestDTOs.Email,
                Password = hashedPassword,
                Created = DateTime.Now,
                RefreshToken=RefreshToken,
                RefreshTokenExpiryDate = DateTime.UtcNow.AddDays(7)
        };
            var response = await userRepositories.addUser(user);
            return await Response.SuccessAsync(response.UserName);
        }
    }
}
