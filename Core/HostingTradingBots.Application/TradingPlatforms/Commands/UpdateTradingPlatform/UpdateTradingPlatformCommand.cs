using MediatR;

namespace HostingTradingBots.Application.TradingPlatforms.Commands.UpdateTradingPlatform
{
  public class UpdateTradingPlatformCommand : IRequest<Unit>
  {
    public Guid Id {get; set;}
    public string Name { get; set; }
    public string SiteLink { get; set; }
    public bool IsActive { get; set; }
    public string? ReferralLink { get; set; }
    public string? ApiLink { get; set; }
    public string? TestApiLink { get; set; }
    public string? DocsLink { get; set; }
    public string? Icon { get; set; }
  }
}
