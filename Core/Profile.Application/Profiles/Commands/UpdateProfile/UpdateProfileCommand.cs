using MediatR;
using System;

namespace Profile.Application.Profiles.Commands.UpdateProfile
{
  public class UpdateProfileCommand: IRequest<Unit>
  {
    public Guid Id {get; set;}
    public Guid UserId {get; set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public byte[] Avatar { get; set; }
    public DateTime DateBirthday { get; set; }
  }

}
