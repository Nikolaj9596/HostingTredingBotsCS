using System.Threading;
using System.Threading.Tasks;
using Profile.Domain;
using Microsoft.EntityFrameworkCore;

namespace Profile.Application.Interfaces
{
  public interface IProfileDBContext
  {
    DbSet<Profile.Domain.Profile> Profiles {get; set;}
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
  }
}
