using FluentValidation;

namespace HostingTradingBots.Application.TradingPlatforms.Commands.CreateTradingPlatform
{
  public class CreateTradingPlatformCommandValidator : AbstractValidator<CreateTradingPlatformCommand>
  {
    public CreateTradingPlatformCommandValidator()
    {
      RuleFor(createTradingPlatformCommand =>
          createTradingPlatformCommand.Name).NotEmpty().MaximumLength(250);
      RuleFor(createTradingPlatformCommand =>
          createTradingPlatformCommand.SiteLink).NotEmpty()
        .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
        .When(x => !string.IsNullOrEmpty(x.SiteLink));
    }
  }
}
