using Application.Dto;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

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

    public async Task<IEnumerable<Announcement>> GetAnnouncementsByFilters(AnnouncementFilterDto filter)
    {
        var query = context.Announcements.AsNoTracking().AsQueryable();


            if (!string.IsNullOrEmpty(filter.Title))
                query = query.Where(a => a.Title.Contains(filter.Title));

            if (!string.IsNullOrEmpty(filter.Content))
                query = query.Where(a => a.Title.Contains(filter.Content));

            if (filter.CreatorId.HasValue)
                query = query.Where(a => a.CreatorId == filter.CreatorId);

            if (filter.DateStart.HasValue)
                query = query.Where(a => a.CreatedAt >= filter.DateStart);

            if (filter.DateEnd.HasValue)
                query = query.Where(a => a.CreatedAt <= filter.DateEnd);
            
        return await query.ToListAsync();
    }
}