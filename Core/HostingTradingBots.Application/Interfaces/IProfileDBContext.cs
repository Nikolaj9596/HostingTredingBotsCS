using Microsoft.EntityFrameworkCore;

namespace HostingTradingBots.Application.Interfaces
{
    public interface IProfileDBContext
    {
        DbSet<Profile.Domain.Profile> Profiles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
