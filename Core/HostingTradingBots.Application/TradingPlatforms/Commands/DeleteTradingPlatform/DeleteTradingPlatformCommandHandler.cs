using MediatR;
using HostingTradingBots.Application.Common.Exceptions;
using HostingTradingBots.Application.Interfaces;

namespace HostingTradingBots.Application.TradingPlatforms.Commands.DeleteTradingPlatform
{
  public class DeleteTradingPlatformCommandHandler : IRequestHandler<DeleteTradingPlatformCommand, Unit>
  {
    private readonly ITradingPlatformDBContext _dbContext;

    public DeleteTradingPlatformCommandHandler(ITradingPlatformDBContext dBContext) =>
      _dbContext = dBContext;

    public async Task<Unit> Handle(DeleteTradingPlatformCommand request, CancellationToken cancellationToken)
    {

      var entity = await _dbContext.TradingPlatforms.FindAsync(new object[] { request.Id }, cancellationToken);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Profile), request.Id);
      }

      _dbContext.TradingPlatforms.Remove(entity);
      await _dbContext.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }

}
