using FluentValidation;

namespace HostingTradingBots.Application.TradingPlatformAccounts.Commands.DeleteTradingPlatformAccount
{
    public class DeleteTradingPlatformAccountCommandValidator : AbstractValidator<DeleteTradingPlatformAccountCommand>
    {
        public DeleteTradingPlatformAccountCommandValidator()
        {
            RuleFor(deleteTradingPlatformAccountCommand =>
                deleteTradingPlatformAccountCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
