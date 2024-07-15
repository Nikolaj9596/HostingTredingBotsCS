using FluentValidation;

namespace HostingTradingBots.Application.TradingPlatformAccounts.Commands.UpdateTradingPlatformAccount
{
  public class UpdateTradingPlatformAccountCommandValidator : AbstractValidator<UpdateTradingPlatformAccountCommand>
  {
    public UpdateTradingPlatformAccountCommandValidator()
    {
      RuleFor(updateTradingPlatformAccountCommand =>
          updateTradingPlatformAccountCommand.Id).NotEqual(Guid.Empty);
    }
  }
}
