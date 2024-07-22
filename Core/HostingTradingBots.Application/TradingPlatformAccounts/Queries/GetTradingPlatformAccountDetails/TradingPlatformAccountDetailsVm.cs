using HostingTradingBots.Application.Common.Mappings;

namespace HostingTradingBots.Application.TradingPlatformsAccounts.Queries.GetTradingPlatformAccountDetails
{
    public class TradingPlatformAccountDetailsVm : IMapWith<TradingPlatformAccount.Domain.TradingPlatformAccount>
    {
        public Guid Id { get; set; }
        public Guid TradingPlatformId { get; set; }
        public Guid UserId { get; set; }
        public Boolean IsActive { get; set; }
        public String ApiKey { get; set; }
        public String? TestApiKey { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ArchivedAt { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<TradingPlatformAccount.Domain.TradingPlatformAccount, TradingPlatformAccountDetailsVm>()
              .ForMember(tradingPlatformAccountVm => tradingPlatformAccountVm.Id,
                  opt => opt.MapFrom(profile => profile.Id))
              .ForMember(tradingPlatformAccountVm => tradingPlatformAccountVm.UserId,
                  opt => opt.MapFrom(profile => profile.UserId))
              .ForMember(tradingPlatformAccountVm => tradingPlatformAccountVm.TradingPlatformId,
                  opt => opt.MapFrom(profile => profile.TradingPlatformId))
              .ForMember(tradingPlatformAccountVm => tradingPlatformAccountVm.IsActive,
                  opt => opt.MapFrom(profile => profile.IsActive))
              .ForMember(tradingPlatformAccountVm => tradingPlatformAccountVm.ApiKey,
                  opt => opt.MapFrom(profile => profile.ApiKey))
              .ForMember(tradingPlatformAccountVm => tradingPlatformAccountVm.TestApiKey,
                  opt => opt.MapFrom(profile => profile.TestApiKey))
              .ForMember(tradingPlatformAccountVm => tradingPlatformAccountVm.CreatedAt,
                  opt => opt.MapFrom(profile => profile.CreatedAt))
              .ForMember(tradingPlatformAccountVm => tradingPlatformAccountVm.UpdatedAt,
                  opt => opt.MapFrom(profile => profile.UpdatedAt));
        }

    }
}
