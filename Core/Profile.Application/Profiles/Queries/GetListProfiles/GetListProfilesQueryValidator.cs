using FluentValidation;

namespace Profile.Application.Profiles.Queries.GetListProfiles
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
