using MediatR;

namespace HostingTradingBots.Application.Profiles.Commands.DeleteProfile
{
  public class DeleteProfileCommand : IRequest<Unit>
  {
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
  }
}


