using MediatR;

namespace HostingTradingBots.Application.TradingPlatformAccounts.Commands.UpdateTradingPlatformAccount
{
    public class UpdateTradingPlatformAccountCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid TradingPlatformId { get; set; }
        public Guid UserId { get; set; }
        public Boolean IsActive { get; set; }
        public String ApiKey { get; set; }
        public String? TestApiKey { get; set; }
    }
}
