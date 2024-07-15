using FluentValidation;

namespace HostingTradingBots.Application.TradingPlatformAccounts.Commands.CreateTradingPlatformAccount
{
    public class CreateTradingPlatformAccountCommandValidator : AbstractValidator<CreateTradingPlatformAccountCommand>
    {
        public CreateTradingPlatformAccountCommandValidator()
        {
            RuleFor(createTradingPlatformAccountCommand =>
                createTradingPlatformAccountCommand.tradingPlatformId).NotEmpty();
            RuleFor(createTradingPlatformAccountCommand =>
                createTradingPlatformAccountCommand.UserId).NotEmpty();
            RuleFor(createTradingPlatformAccountCommand =>
                createTradingPlatformAccountCommand.ApiKey).NotEmpty();
        }
    }
}
