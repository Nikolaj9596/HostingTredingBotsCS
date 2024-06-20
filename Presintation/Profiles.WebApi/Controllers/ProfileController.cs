using System;
using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Profile.Application.Profiles.Queries.GetListProfiles;
using Profile.Application.Profiles.Queries.GetProfileDetails;
using Profile.Application.Profiles.Commands.CreateProfile;
using Profile.Application.Profiles.Commands.UpdateProfile;
using Profile.Application.Profiles.Commands.DeleteProfile;
using Profile.WebApi.Models;

namespace Profile.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProfileController : BaseController
    {
        private readonly IMapper _mapper;
        public ProfileController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ListProfilesVm>> GetAll()
        {
            var query = new GetListProfilesQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileDetailsVm>> Get(Guid id)
        {
            var query = new GetProfileDetailsQuery
            { UserId = UserId, Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProfileDto createProfileDto)
        {
            var command = _mapper.Map<CreateProfileCommand>(createProfileDto);
            command.UserId = UserId;
            var profileId = await Mediator.Send(command);
            return Ok(profileId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProfileDto updateProfileDto)
        {
            var command = _mapper.Map<UpdateProfileCommand>(updateProfileDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProfileCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
