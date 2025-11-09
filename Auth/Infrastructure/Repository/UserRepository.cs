using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class UserRepository(UserContext context): IUserRepository
{
    public async Task AddAsync(User user)
    {
        await context.AddAsync(user);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<User?> GetFirstOrDefaultByGuidAsync(Guid guid)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.UserGuid == guid);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public void Update(User user)
    {
        context.Users.Update(user);
    }
}