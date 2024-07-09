using MediatR;
using HostingTradingBots.Application.Interfaces;

namespace HostingTradingBots.Application.TradingPlatforms.Commands.CreateTradingPlatform
{
  public class CreateTradingPlatformCommandHandler : IRequestHandler<CreateTradingPlatformCommand, Guid>
  {
    private readonly ITradingPlatformDBContext _dbContext;

    public CreateTradingPlatformCommandHandler(ITradingPlatformDBContext dBContext) =>
      _dbContext = dBContext;

    public async Task<Guid> Handle(CreateTradingPlatformCommand request, CancellationToken cancellationToken)
    {
      var tradingPlatform = new TradingPlatform.Domain.TradingPlatform
      {
        Id = Guid.NewGuid(),
        Name = request.Name,
        SiteLink = request.SiteLink,
        IsActive = request.IsActive,
        ReferralLink = request.ReferralLink,
        ApiLink = request.ApiLink,
        TestApiLink = request.TestApiLink,
        DocsLink = request.DocsLink,
        Icon = request.Icon,
        CreatedAt = DateTime.Now,
        UpdatedAt = null

      };

      await _dbContext.TradingPlatforms.AddAsync(tradingPlatform, cancellationToken);
      await _dbContext.SaveChangesAsync(cancellationToken);
      return tradingPlatform.Id;
    }
  }

}
