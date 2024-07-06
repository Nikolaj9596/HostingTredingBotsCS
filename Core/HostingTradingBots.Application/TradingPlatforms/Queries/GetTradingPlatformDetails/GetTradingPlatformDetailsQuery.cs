using MediatR;

namespace HostingTradingBots.Application.TradingPlatforms.Queries.GetTradingPlatformDetails
{
  public class GetTradingPlatformDetailsQuery : IRequest<TradingPlatformDetailsVm>
  {
    public Guid Id { get; set; }

  }
}
