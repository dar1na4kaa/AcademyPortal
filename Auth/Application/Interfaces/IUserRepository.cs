using Domain.Entities;

namespace Application.Interfaces;

public interface IUserRepository
{
    public Task AddAsync(User user);

    public Task<User?> GetByIdAsync(int id);
    public Task<User?> GetFirstOrDefaultByGuidAsync(Guid guid);

    public Task SaveChangesAsync();

    public void Update(User user);
}