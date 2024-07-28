using HostingTradingBots.Application.Common.Mappings;
using HostingTradingBots.Application.TradingPlatformAccounts.Commands.UpdateTradingPlatformAccount;

namespace HostingTradingBots.WebApi.Models
{
    public class UpdateTradingPlatformAccountDto : IMapWith<UpdateTradingPlatformAccountCommand>
    {
        public Guid TradingPlatformId { get; set; }
        public Guid UserId { get; set; }
        public Boolean IsActive { get; set; }
        public String ApiKey { get; set; }
        public String? TestApiKey { get; set; }

        public void Mappings(AutoMapper.Profile profile)
        {
            profile.CreateMap<UpdateTradingPlatformAccountDto, UpdateTradingPlatformAccountCommand>()
              .ForMember(tradingPlatformAccountCommand => tradingPlatformAccountCommand.TradingPlatformId,
                  opt => opt.MapFrom(tradingPlatformAccountDto => tradingPlatformAccountDto.TradingPlatformId))
              .ForMember(tradingPlatformAccountCommand => tradingPlatformAccountCommand.UserId,
                  opt => opt.MapFrom(tradingPlatformAccountDto => tradingPlatformAccountDto.UserId))
              .ForMember(tradingPlatformAccountCommand => tradingPlatformAccountCommand.IsActive,
                  opt => opt.MapFrom(tradingPlatformAccountDto => tradingPlatformAccountDto.IsActive))
              .ForMember(tradingPlatformAccountCommand => tradingPlatformAccountCommand.ApiKey,
                  opt => opt.MapFrom(tradingPlatformAccountDto => tradingPlatformAccountDto.ApiKey))
              .ForMember(tradingPlatformAccountCommand => tradingPlatformAccountCommand.TestApiKey,
                  opt => opt.MapFrom(tradingPlatformAccountDto => tradingPlatformAccountDto.TestApiKey));
        }
    }
}
