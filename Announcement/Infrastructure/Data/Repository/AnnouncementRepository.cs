using Application;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository;

public class AnnouncementRepository(AnnouncementContext context): IAnnouncementRepository
{
    public async Task<Announcement> GetByGuidAsync(Guid guid)
    {
        var annon = await context.Announcements.Where(e => e.Guid == guid).FirstOrDefaultAsync();
        return annon;
    }
    public async Task CreateAsync(AnnouncementDTO announcement)
    {
        var entity = announcement.Map();
        await context.Announcements.AddAsync(entity);
    }
    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();  
    }
/*    public async Task<Announcement> GetByPublishedDateAsync(DateOnly date)
    {
        var annon = await context.Announcements.Where(e => e.CreatedAt == date).FirstOrDefaultAsync();
        return annon;
    }
    public async Task<Announcement> GetByAuthorAsync(Guid creatorId)
    {
        var annon = await context.Announcements.Where(e => e.CreatorId == creatorId).FirstOrDefaultAsync();
        return annon;
    }
    public async Task<bool> ExistsAsync(Guid guid)
    {
        var annon = await GetByGuidAsync(guid);
        var isActive = annon.IsActive;
        return isActive;
    }
    public async Task DeleteAsync(Guid guid)
    {

    }*/
}