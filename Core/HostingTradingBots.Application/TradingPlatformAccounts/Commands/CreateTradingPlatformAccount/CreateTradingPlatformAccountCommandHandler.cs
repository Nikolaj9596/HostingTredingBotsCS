using MediatR;
using HostingTradingBots.Application.Interfaces;

namespace HostingTradingBots.Application.TradingPlatformAccounts.Commands.CreateTradingPlatformAccount
{
    public class CreateTradingPlatformAccountCommandHandler : IRequestHandler<CreateTradingPlatformAccountCommand, Guid>
    {
        private readonly ITradingPlatformAccountDBContext _dbContext;

        public CreateTradingPlatformAccountCommandHandler(ITradingPlatformAccountDBContext dBContext) =>
          _dbContext = dBContext;

        public async Task<Guid> Handle(CreateTradingPlatformAccountCommand request, CancellationToken cancellationToken)
        {
            var tradingPlatformAccount = new TradingPlatformAccount.Domain.TradingPlatformAccount
            {
                Id = Guid.NewGuid(),
                TradingPlatformId = request.TradingPlatformId,
                IsActive = request.IsActive,
                UserId = request.UserId,
                ApiKey = request.ApiKey,
                TestApiKey = request.TestApiKey,
                CreatedAt = DateTime.Now,
                UpdatedAt = null

            };

            await _dbContext.TradingPlatformsAccounts.AddAsync(
                tradingPlatformAccount, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return tradingPlatformAccount.Id;
        }
    }

}
