using FluentValidation;

namespace HostingTradingBots.Application.TradingPlatforms.Commands.DeleteTradingPlatform
{
  public class DeleteTradingPlatformCommandValidator : AbstractValidator<DeleteTradingPlatformCommand>
  {
    public DeleteTradingPlatformCommandValidator()
    {
      RuleFor(deleteTradingPlatformCommand =>
          deleteTradingPlatformCommand.Id).NotEqual(Guid.Empty);
    }
  }
}
