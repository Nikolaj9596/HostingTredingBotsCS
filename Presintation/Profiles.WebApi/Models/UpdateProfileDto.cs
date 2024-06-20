using AutoMapper;
using Profile.Application.Common.Mappings;
using Profile.Application.Profiles.Commands.UpdateProfile;

namespace Profile.WebApi.Models
{
  public class UpdateProfileDto: IMapWith<UpdateProfileCommand>
  {
    public Guid Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string MiddleName {get; set;}
    public DateTime DateBirthday { get; set; }
    public byte[] Avatar { get; set; }
    
    public void Mappings(AutoMapper.Profile profile)
    {
      profile.CreateMap<UpdateProfileDto, UpdateProfileCommand>()
        .ForMember(profileCommand => profileCommand.Id,
            opt => opt.MapFrom(profileDto => profileDto.Id))
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
