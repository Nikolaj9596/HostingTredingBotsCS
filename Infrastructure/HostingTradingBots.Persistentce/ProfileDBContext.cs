using Microsoft.EntityFrameworkCore;
using HostingTradingBots.Application.Interfaces;
using HostingTradingBots.Persistentce.EntityTypeConfiguration;

namespace HostingTradingBots.Persistentce 
{
  public class ProfileDBContext: DbContext, IProfileDBContext
 {
    public DbSet<Profile.Domain.Profile> Profiles {get; set;}
    public ProfileDBContext(DbContextOptions<ProfileDBContext> options)
      :base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ProfileConfiguration());
      base.OnModelCreating(modelBuilder);
    }
  }
}
