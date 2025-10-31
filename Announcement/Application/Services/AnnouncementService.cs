using Application.Interfaces;

namespace Application.Services;

public class AnnouncementService(IAnnouncementRepository repository): IAnnouncementService
{
    public async Task CreateAsync(AnnouncementDTO announcement)
    {
       await repository.CreateAsync(announcement);
       await repository.SaveAsync();
    }
}