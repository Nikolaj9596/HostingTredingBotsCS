using AutoMapper;
using HostingTradingBots.Application.Common.Mappings;
using HostingTradingBots.Application.Profiles.Commands.CreateProfile;

namespace HostingTradingBots.WebApi.Models
{
    public class CreateProfileDto : IMapWith<CreateProfileCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateBirthday { get; set; }
        public byte[] Avatar { get; set; }

        public void Mappings(AutoMapper.Profile profile)
        {
            profile.CreateMap<CreateProfileDto, CreateProfileCommand>()
              .ForMember(profileCommand => profileCommand.FirstName,
                  opt => opt.MapFrom(profileDto => profileDto.FirstName))
              .ForMember(profileCommand => profileCommand.LastName,
                  opt => opt.MapFrom(profileDto => profileDto.LastName))
              .ForMember(profileCommand => profileCommand.MiddleName,
                  opt => opt.MapFrom(profileDto => profileDto.MiddleName))
              .ForMember(profileCommand => profileCommand.DateBirthday,
                  opt => opt.MapFrom(profileDto => profileDto.DateBirthday))
              .ForMember(profileCommand => profileCommand.Avatar,
                  opt => opt.MapFrom(profileDto => profileDto.Avatar));
        }
    }
}
