using Domain.Entities;

namespace Application.Interfaces;

public interface IAnnouncementRepository
{
    public Task<Announcement> GetByGuidAsync(Guid guid);
}