using MediatR;

namespace Profile.Application.Profiles.Commands.CreateProfile
{
  public class CreateProfileCommand: IRequest<Guid>
  {
    public Guid UserId {get; set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateBirthday { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public byte[] Avatar { get; set; }
  }

}
