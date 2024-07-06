using MediatR;

namespace HostingTradingBots.Application.TradingPlatforms.Commands.DeleteTradingPlatform
{
  public class DeleteTradingPlatformCommand : IRequest<Unit>
  {
    public Guid Id { get; set; }
  }
}
