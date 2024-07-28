using MediatR;

namespace HostingTradingBots.Application.TradingPlatformsAccounts.Queries.GetTradingPlatformAccountDetails
{
    public class GetTradingPlatformAccountDetailsQuery : IRequest<TradingPlatformAccountDetailsVm>
    {
        public Guid Id { get; set; }

    }
}
