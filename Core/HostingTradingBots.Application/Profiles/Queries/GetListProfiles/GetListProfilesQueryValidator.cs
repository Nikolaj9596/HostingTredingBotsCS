using FluentValidation;

namespace HostingTradingBots.Application.Profiles.Queries.GetListProfiles
{
    public class GetListProfilesQueryValidator : AbstractValidator<GetListProfilesQuery>
    {
        public GetListProfilesQueryValidator()
        {
            RuleFor(updateProfileCommand =>
                updateProfileCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
