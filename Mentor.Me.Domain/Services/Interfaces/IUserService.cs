using Mentor.Me.Data.Entities;

namespace Mentor.Me.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(Guid userId);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> UpdateUserAsync(User user);
        Task<User> AddUserAsync(User user);
        Task<bool> RemoveUserByIdAsync(Guid userId);
        Task<User> GetUserByEmailIfExistAsync(string email, CancellationToken ct);
        Task CreateNewUserIfNotExistAsync(string email, string userName, CancellationToken ct);
    }
}