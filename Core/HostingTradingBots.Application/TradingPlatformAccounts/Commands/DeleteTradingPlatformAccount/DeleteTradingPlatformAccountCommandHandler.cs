using MediatR;
using HostingTradingBots.Application.Common.Exceptions;
using HostingTradingBots.Application.Interfaces;

namespace HostingTradingBots.Application.TradingPlatformAccounts.Commands.DeleteTradingPlatformAccount
{
    public class DeleteTradingPlatformAccountCommandHandler : IRequestHandler<DeleteTradingPlatformAccountCommand, Unit>
    {
        private readonly ITradingPlatformAccountDBContext _dbContext;

        public DeleteTradingPlatformAccountCommandHandler(ITradingPlatformAccountDBContext dBContext) =>
          _dbContext = dBContext;

        public async Task<Unit> Handle(DeleteTradingPlatformAccountCommand request, CancellationToken cancellationToken)
        {

            var entity = await _dbContext.TradingPlatformAccounts.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Profile), request.Id);
            }

            _dbContext.TradingPlatformAccounts.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
