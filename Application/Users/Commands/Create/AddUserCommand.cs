using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Create
{
    public record AddUserCommand(User user) : IRequest<User>;
    public class AddUserCommandHandler(IUserRepositories repositories) : IRequestHandler<AddUserCommand, User>
    {
        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return await repositories.addUser(request.user);
        }
    }
}
