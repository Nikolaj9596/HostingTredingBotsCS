using MediatR;

namespace HostingTradingBots.Application.TradingPlatforms.Commands.CreateTradingPlatform
{
  public class CreateTradingPlatformCommand : IRequest<Guid>
  {
    public string Name { get; set; }
    public string SiteLink { get; set; }
    public bool IsActive { get; set; }
    public string? ReferralLink { get; set; }
    public string? ApiLink { get; set; }
    public string? TestApiLink { get; set; }
    public string? DocsLink { get; set; }
    public string? Icon { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? ArchivedAt { get; set; }
  }
}