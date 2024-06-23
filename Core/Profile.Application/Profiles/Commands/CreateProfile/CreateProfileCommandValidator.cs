using FluentValidation;

namespace Profile.Application.Profiles.Commands.CreateProfile
{
    public class CreateProfileCommandValidator : AbstractValidator<CreateProfileCommand>
    {
        public CreateProfileCommandValidator()
        {
            RuleFor(createProfileCommand =>
                createProfileCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createProfileCommand =>
                createProfileCommand.FirstName).NotEmpty().MaximumLength(250);
            RuleFor(createProfileCommand =>
                createProfileCommand.LastName).NotEmpty().MaximumLength(250);
            RuleFor(createProfileCommand =>
                createProfileCommand.MiddleName).NotEmpty().MaximumLength(250);
        }
    }
}
