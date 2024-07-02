using FluentValidation;

namespace HostingTradingBots.Application.Profiles.Commands.DeleteProfile
{
    public class DeleteProfileCommandValidator : AbstractValidator<DeleteProfileCommand>
    {
        public DeleteProfileCommandValidator()
        {
            RuleFor(updateProfileCommand =>
                updateProfileCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateProfileCommand =>
                updateProfileCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
