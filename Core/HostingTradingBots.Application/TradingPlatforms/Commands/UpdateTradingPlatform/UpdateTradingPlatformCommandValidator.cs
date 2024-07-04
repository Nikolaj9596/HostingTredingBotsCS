using FluentValidation;

namespace HostingTradingBots.Application.TradingPlatforms.Commands.UpdateTradingPlatform
{
  public class UpdateTradingPlatformCommandValidator : AbstractValidator<UpdateTradingPlatformCommand>
  {
    public UpdateTradingPlatformCommandValidator()
    {
      RuleFor(updateTradingPlatformCommand =>
          updateTradingPlatformCommand.Id).NotEqual(Guid.Empty);
      RuleFor(updateTradingPlatformCommand =>
          updateTradingPlatformCommand.Name).NotEmpty().MaximumLength(250);
      RuleFor(updateTradingPlatformCommand =>
          updateTradingPlatformCommand.SiteLink).NotEmpty()
        .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
        .When(x => !string.IsNullOrEmpty(x.SiteLink));
    }
  }
}
