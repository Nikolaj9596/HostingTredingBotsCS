using System;
using MediatR;

namespace Profile.Application.Profiles.Commands.DeleteProfile
{
  public class DeleteProfileCommand : IRequest<Unit>
  {
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
  }
}


