using FluentValidation;

namespace HostingTradingBots.Application.Profiles.Commands.DeleteProfile
{
  public class DeleteProfileCommandValidator : AbstractValidator<DeleteProfileCommand>
  {
    public DeleteProfileCommandValidator()
    {
      RuleFor(deleteProfileCommand =>
          deleteProfileCommand.Id).NotEqual(Guid.Empty);
      RuleFor(deleteProfileCommand =>
          deleteProfileCommand.UserId).NotEqual(Guid.Empty);
    }
  }
}
