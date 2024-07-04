using MediatR;
using HostingTradingBots.Application.Interfaces;
using HostingTradingBots.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HostingTradingBots.Application.TradingPlatforms.Commands.UpdateTradingPlatform
{
  public class UpdateTradingPlatformCommandHandler : IRequestHandler<UpdateTradingPlatformCommand, Unit>
  {
    private readonly ITradingPlatrformDBContext _dbContext;

    public UpdateTradingPlatformCommandHandler(ITradingPlatrformDBContext dBContext) =>
      _dbContext = dBContext;

    public async Task<Unit> Handle(UpdateTradingPlatformCommand request, CancellationToken cancellationToken)
    {
      var entity =
        await _dbContext.TradingPlatforms.FirstOrDefaultAsync(tradingPlatform =>
            tradingPlatform.Id == request.Id, cancellationToken);

      if (entity == null)
      {
        throw new NotFoundException(nameof(TradingPlatform.Domain.TradingPlatform), request.Id);
      }
      entity.Name = request.Name;
      entity.SiteLink = request.SiteLink;
      entity.IsActive = request.IsActive;
      entity.ReferralLink = request.ReferralLink;
      entity.ApiLink = request.ApiLink;
      entity.TestApiLink = request.TestApiLink;
      entity.DocsLink = request.DocsLink;
      entity.Icon = request.Icon;
      entity.UpdatedAt = DateTime.Now;

      await _dbContext.SaveChangesAsync(cancellationToken);
      return Unit.Value;
    }
  }

}
