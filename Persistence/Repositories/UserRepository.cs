using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Shared.Utils.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepositories
    {
        public async Task<User> addUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<(IEnumerable<User> Users, int TotalRecords)> GetUsersPagedAsync(
           int pageNumber,
           int pageSize,
           string? sortColumn,
           string? sortDirection,
           IDictionary<string, string>? filters)
        {
            try
            {
                var query = context.Users.AsQueryable();

                // Apply filters, sorting, and pagination logic (same as before)
                if (filters != null)
                {
                    // Filter logic
                }

                if (!string.IsNullOrEmpty(sortColumn))
                {
                    query = sortDirection?.ToLower() == "desc"
                        ? query.OrderByDescending(e => EF.Property<object>(e, sortColumn))
                        : query.OrderBy(e => EF.Property<object>(e, sortColumn));
                }

                int totalRecords = await query.CountAsync();

                var users = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return (users, totalRecords);
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<User> GetUserById(int Id)
        {
            return await context.Users.FirstAsync(x => x.Id == Id);
        }

        public async Task<User> getUserByEmail(string email)
        {
            return await context.Users.FirstAsync(x => x.Email == email);
        }

        public async Task<bool> updateAsync(User user)
        {
            var existingUser = await context.Users.FirstAsync(x=>x.Id==user.Id);

            if (existingUser == null)
            {
                return false; // User not found
            }

            // Update properties manually
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.RefreshToken= user.RefreshToken;
            existingUser.RefreshTokenExpiryDate= user.RefreshTokenExpiryDate;
            // Update other fields as needed
            await context.SaveChangesAsync();

            return true;

        }
    }
}
