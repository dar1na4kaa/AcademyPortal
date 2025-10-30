using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository;

public class AnnouncementRepository(AnnouncementContext context): IAnnouncementRepository
{
    public async Task<Announcement> GetByGuidAsync(Guid guid)
    {
        var annon = await context.Announcements.Where(e => e.Guid == guid).FirstOrDefaultAsync();
        return annon;
    }
}