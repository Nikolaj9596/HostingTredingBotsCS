using FluentValidation;

namespace HostingTradingBots.Application.TradingPlatformsAccounts.Queries.GetTradingPlatformAccountDetails
{
    public class GetTradingPlatformAccountDetailsQueryValidator : AbstractValidator<GetTradingPlatformAccountDetailsQuery>
    {
        public GetTradingPlatformAccountDetailsQueryValidator()
        {
            RuleFor(getTradingPlatformAccountDetailsQuery =>
                getTradingPlatformAccountDetailsQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
