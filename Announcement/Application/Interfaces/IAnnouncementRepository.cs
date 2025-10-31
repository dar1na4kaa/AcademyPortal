using Domain.Entities;

namespace Application.Interfaces;

public interface IAnnouncementRepository
{
    public Task CreateAsync(AnnouncementDTO announcement);
    public Task<Announcement> GetByGuidAsync(Guid guid);
    public Task SaveAsync();
    /*  public Task<Announcement> GetByPublishedDateAsync(DateOnly date);
        public Task<Announcement> GetByAuthorAsync(Guid creatorId);
        public Task<bool> ExistsAsync(Guid guid);
        public Task DeleteAsync(Guid guid);*/
}