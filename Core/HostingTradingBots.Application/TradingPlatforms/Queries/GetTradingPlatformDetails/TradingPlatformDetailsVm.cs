using HostingTradingBots.Application.Common.Mappings;

namespace HostingTradingBots.Application.TradingPlatforms.Queries.GetTradingPlatformDetails
{
  public class TradingPlatformDetailsVm : IMapWith<TradingPlatform.Domain.TradingPlatform>
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string SiteLink { get; set; }
    public bool IsActive { get; set; }
    public string? ReferralLink { get; set; }
    public string? ApiLink { get; set; }
    public string? TestApiLink { get; set; }
    public string? DocsLink { get; set; }
    public string? Icon { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? ArchivedAt { get; set; }

    public void Mapping(AutoMapper.Profile profile)
    {
      profile.CreateMap<TradingPlatform.Domain.TradingPlatform, TradingPlatformDetailsVm>()
        .ForMember(tradingPlatformVm => tradingPlatformVm.Id,
            opt => opt.MapFrom(profile => profile.Id))
        .ForMember(tradingPlatformVm => tradingPlatformVm.Name,
            opt => opt.MapFrom(profile => profile.Name))
        .ForMember(tradingPlatformVm => tradingPlatformVm.SiteLink,
            opt => opt.MapFrom(profile => profile.SiteLink))
        .ForMember(tradingPlatformVm => tradingPlatformVm.IsActive,
            opt => opt.MapFrom(profile => profile.IsActive))
        .ForMember(tradingPlatformVm => tradingPlatformVm.Icon,
            opt => opt.MapFrom(profile => profile.Icon))
        .ForMember(tradingPlatformVm => tradingPlatformVm.ReferralLink,
            opt => opt.MapFrom(profile => profile.ReferralLink))
        .ForMember(tradingPlatformVm => tradingPlatformVm.ApiLink,
            opt => opt.MapFrom(profile => profile.ApiLink))
        .ForMember(tradingPlatformVm => tradingPlatformVm.DocsLink,
            opt => opt.MapFrom(profile => profile.DocsLink))
        .ForMember(tradingPlatformVm => tradingPlatformVm.TestApiLink,
            opt => opt.MapFrom(profile => profile.TestApiLink))
        .ForMember(tradingPlatformVm => tradingPlatformVm.CreatedAt,
            opt => opt.MapFrom(profile => profile.CreatedAt))
        .ForMember(tradingPlatformVm => tradingPlatformVm.UpdatedAt,
            opt => opt.MapFrom(profile => profile.UpdatedAt));
    }

  }
}
