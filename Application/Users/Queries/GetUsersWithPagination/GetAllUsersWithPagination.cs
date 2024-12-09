using Application.Common.DTOs.User;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Shared.Utils.Wrapper;

namespace Application.Users.Queries.GetUsersWithPagination
{
    public record GetAllUsersWithPagination(int pageNumber, string sortColumn, string sortDirection, string filters ) : IRequest<IPagedResponse<IEnumerable<UserResponseDTOs>>>
    {
        public int ListId { get; init; }
        public int PageNumber { get; init; } = pageNumber;
        public int PageSize { get; init; } = 10;
        public string SortColumn { get; init; } = sortColumn;
        public string SortDirection { get; init; } = sortDirection;
        public string Filter { get; init; } = filters;

    }
    public class GetAllUsersWithPaginationQueryHandler(IUserRepositories userRepositories) : IRequestHandler<GetAllUsersWithPagination, IPagedResponse<IEnumerable<UserResponseDTOs>>>
    {
        public async Task<IPagedResponse<IEnumerable<UserResponseDTOs>>> Handle(GetAllUsersWithPagination request, CancellationToken cancellationToken)
        {
            var (users, totalRecords) = await userRepositories.GetUsersPagedAsync(
                request.PageNumber,
                request.PageSize,
                request.SortColumn, 
                request.SortDirection,
                null
            );

            var userDtos = users.Select(user => new UserResponseDTOs
            {
                UserName = user.UserName,
                Email = user.Email,
                Id = user.Id
            });

            return new PagedResponse<IEnumerable<UserResponseDTOs>>(
                userDtos,
                request.PageNumber,
                request.PageSize,
                totalRecords)
                {
                    SortColumn = request.sortColumn,          
                    SortDirection = request.sortDirection,       
                    Filters = null              
                };
        }
    }
}
