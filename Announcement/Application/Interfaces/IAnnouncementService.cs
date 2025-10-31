using Domain.Entities;

namespace Application.Interfaces;

public interface IAnnouncementService
{
    public Task CreateAsync(AnnouncementDTO announcement);
}