using MediatR;
using HostingTradingBots.Application.Interfaces;
using HostingTradingBots.Application.Common.Exceptions; 

namespace HostingTradingBots.Application.Profiles.Commands.DeleteProfile
{
    public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, Unit>
    {
        private readonly IProfileDBContext _dbContext;

        public DeleteProfileCommandHandler(IProfileDBContext dBContext) =>
            _dbContext = dBContext;

        public async Task<Unit> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Profiles.FindAsync(new object[] {request.Id}, cancellationToken);
            
            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Profile), request.Id);
            }
        
            _dbContext.Profiles.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}

