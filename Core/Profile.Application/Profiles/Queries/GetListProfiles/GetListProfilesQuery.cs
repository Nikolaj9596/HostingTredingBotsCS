using System;
using MediatR;

namespace Profile.Application.Profiles.Queries.GetListProfiles 
{
  public class GetListProfilesQuery: IRequest<ListProfilesVm> 
  {
    public Guid UserId {get; set;}
  }
}
