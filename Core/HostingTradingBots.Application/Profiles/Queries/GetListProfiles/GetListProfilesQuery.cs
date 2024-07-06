using MediatR;

namespace HostingTradingBots.Application.Profiles.Queries.GetListProfiles 
{
  public class GetListProfilesQuery: IRequest<ListProfilesVm> 
  {
    public Guid UserId {get; set;}
  }
}
