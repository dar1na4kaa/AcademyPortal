using Application.Dto;
using Application.Interfaces;
using Application.Mappers;

namespace Application.Services;

public class AnnouncementService(IAnnouncementRepository repository): IAnnouncementService
{
    public async Task CreateAsync(CreateAnnouncementDto createAnnouncement)
    {
       await repository.CreateAsync(createAnnouncement);
       await repository.SaveAsync();
       Console.WriteLine("asdasd");
    }
    public async Task<IEnumerable<CreateAnnouncementDto>> GetAnnouncementsByFilters(AnnouncementQueryParameters filter)
    {
        var announcements = await repository.GetAnnouncementsByFilters(filter);

        return announcements.Select(a => a.Map());
    }
}