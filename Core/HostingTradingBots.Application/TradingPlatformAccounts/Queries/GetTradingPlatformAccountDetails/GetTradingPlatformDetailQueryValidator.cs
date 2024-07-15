using FluentValidation;

namespace HostingTradingBots.Application.TradingPlatforms.Queries.GetTradingPlatformDetails
{
  public class GetTradingPlatformDetailsQueryValidator : AbstractValidator<GetTradingPlatformDetailsQuery>
  {
    public GetTradingPlatformDetailsQueryValidator()
    {
      RuleFor(getListTradingPlatformQuery =>
          getListTradingPlatformQuery.Id).NotEqual(Guid.Empty);
    }
  }
}
