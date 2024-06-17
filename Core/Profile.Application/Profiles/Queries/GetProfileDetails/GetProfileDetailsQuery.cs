using System;
using MediatR;

namespace Profile.Application.Profiles.Queries.GetProfileDetails
{
  public class GetProfileDetailsQuery: IRequest<ProfileDetailsVm>
  {
    public Guid UserId {get; set;}
    public Guid Id {get; set;}

  }
}
