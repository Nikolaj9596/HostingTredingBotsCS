using FluentValidation;

namespace HostingTradingBots.Application.Profiles.Queries.GetProfileDetails
{
    public class GetProfileDetailsQueryValidator : AbstractValidator<GetProfileDetailsQuery>
    {
        public GetProfileDetailsQueryValidator()
        {
            RuleFor(updateProfileCommand =>
                updateProfileCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateProfileCommand =>
                updateProfileCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
