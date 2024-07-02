using FluentValidation;

namespace HostingTradingBots.Application.Profiles.Commands.UpdateProfile
{
    public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
    {
        public UpdateProfileCommandValidator()
        {
            RuleFor(updateProfileCommand =>
                updateProfileCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateProfileCommand =>
                updateProfileCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateProfileCommand =>
                updateProfileCommand.FirstName).NotEmpty().MaximumLength(250);
            RuleFor(updateProfileCommand =>
                updateProfileCommand.LastName).NotEmpty().MaximumLength(250);
            RuleFor(updateProfileCommand =>
                updateProfileCommand.MiddleName).NotEmpty().MaximumLength(250);
        }
    }
}
