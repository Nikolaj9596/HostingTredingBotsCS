using MediatR;
using HostingTradingBots.Application.Interfaces;
using HostingTradingBots.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HostingTradingBots.Application.TradingPlatformAccounts.Commands.UpdateTradingPlatformAccount
{
    public class UpdateTradingPlatformAccountCommandHandler : IRequestHandler<UpdateTradingPlatformAccountCommand, Unit>
    {
        private readonly ITradingPlatformAccountDBContext _dbContext;

        public UpdateTradingPlatformAccountCommandHandler(ITradingPlatformAccountDBContext dBContext) =>
          _dbContext = dBContext;

        public async Task<Unit> Handle(UpdateTradingPlatformAccountCommand request, CancellationToken cancellationToken)
        {
            var entity =
              await _dbContext.TradingPlatformsAccounts.FirstOrDefaultAsync(tradingPlatformAccount =>
                  tradingPlatformAccount.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TradingPlatformAccount.Domain.TradingPlatformAccount), request.Id);
            }
            entity.IsActive = request.IsActive;
            entity.TradingPlatformId = request.TradingPlatformId;
            entity.UserId = request.UserId;
            entity.ApiKey = request.ApiKey;
            entity.TestApiKey = request.TestApiKey;
            entity.UpdatedAt = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }

}
