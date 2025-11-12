using Application.Dto;
using Domain.Entities;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Application.Interfaces;

public interface IAnnouncementRepository
{
    public Task CreateAsync(AnnouncementDTO announcement);
    public Task<Announcement> GetByGuidAsync(Guid guid);
    public Task SaveAsync();
    public Task<IEnumerable<Announcement>> GetAnnouncementsByFilters(AnnouncementFilterDto filter);
}