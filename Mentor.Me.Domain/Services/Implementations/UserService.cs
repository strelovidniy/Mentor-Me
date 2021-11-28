using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mentor.Me.Data.Entities;
using Mentor.Me.Data.Infrastructure;
using Mentor.Me.Domain.Extensions.ServicesExtensions;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mentor.Me.Domain.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository) =>
            _userRepository = userRepository;

        public Task<User> GetUserByIdAsync(Guid userId)
            => _userRepository
                .Query()
                .IncludeAll()
                .FirstOrDefaultAsync(user => user.Id == userId)!;
        

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _userRepository.Query().ToListAsync();

        public async Task<User> UpdateUserAsync(User user)
        {
            var updatingUser = await _userRepository.GetByIdAsync(user.Id);

            if (updatingUser == null) return null;

            updatingUser.FullName = user.FullName;
            updatingUser.Deals = user.Deals;
            updatingUser.ApplyRequests = user.ApplyRequests;
            updatingUser.Bio = user.Bio;
            updatingUser.Propositions = user.Propositions;
            updatingUser.Tasks = user.Tasks;
            updatingUser.Email = user.Email;

            await _userRepository.SaveChangesAsync();

            return updatingUser;
        }

        public async Task<User> AddUserAsync(User user)
        {
            var addedUser = await _userRepository.AddAsync(user);

            await _userRepository.SaveChangesAsync();

            return addedUser;
        }

        public async Task<bool> RemoveUserByIdAsync(Guid userId)
        {
            var deletingUser = await _userRepository.GetByIdAsync(userId);

            if (deletingUser is null) return false;

            var result = await _userRepository.DeleteAsync(deletingUser);

            await _userRepository.SaveChangesAsync();

            return result;
        }
        
        public async Task<User> GetUserByEmailIfExistAsync(string email, CancellationToken ct) =>
            (await _userRepository
                .Query()
                .FirstOrDefaultAsync(user => user.Email == email, ct))!;
        
        public async Task CreateNewUserIfNotExistAsync(string email, string userName, CancellationToken ct)
        {
            var existUser = await GetUserByEmailIfExistAsync(email, ct);

            if (existUser == null)
            {
                await AddUserAsync(new User
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    FullName = userName,
                    Bio = "bio"
                });
            }
        }
    }
}
