using MediatR;

namespace HostingTradingBots.Application.Profiles.Queries.GetProfileDetails
{
  public class GetProfileDetailsQuery: IRequest<ProfileDetailsVm>
  {
    public Guid UserId {get; set;}
    public Guid Id {get; set;}

  }
}
