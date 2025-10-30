using Application.Interfaces;

namespace Application.Services;

public class AnnouncementService(IAnnouncementRepository repository): IAnnouncementService
{
    public void Test()
    {
        repository.GetByGuidAsync(Guid.NewGuid());
    }
}