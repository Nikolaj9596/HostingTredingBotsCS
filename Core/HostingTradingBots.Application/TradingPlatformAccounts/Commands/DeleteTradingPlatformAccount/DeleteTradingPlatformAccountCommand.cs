using MediatR;

namespace HostingTradingBots.Application.TradingPlatformAccounts.Commands.DeleteTradingPlatformAccount
{
  public class DeleteTradingPlatformAccountCommand : IRequest<Unit>
  {
    public Guid Id { get; set; }
  }
}
