using Application.Dto;
using Application.Interfaces;
using Application.Mappers;

namespace Application.Services;

public class AnnouncementService(IAnnouncementRepository repository): IAnnouncementService
{
    public async Task CreateAsync(AnnouncementDTO announcement)
    {
       await repository.CreateAsync(announcement);
       await repository.SaveAsync();
    }
    public async Task<IEnumerable<AnnouncementDTO>> GetAnnouncementsByFilters(AnnouncementFilterDto filter)
    {
        var announcements = await repository.GetAnnouncementsByFilters(filter);

        return announcements.Select(a => a.Map());
    }
}