using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HostingTradingBots.Application.Profiles.Queries.GetListProfiles;
using HostingTradingBots.Application.Profiles.Queries.GetProfileDetails;
using HostingTradingBots.Application.Profiles.Commands.CreateProfile;
using HostingTradingBots.Application.Profiles.Commands.UpdateProfile;
using HostingTradingBots.Application.Profiles.Commands.DeleteProfile;
using HostingTradingBots.WebApi.Models;

namespace HostingTradingBots.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class ProfileController : BaseController
    {
        private readonly IMapper _mapper;
        public ProfileController(IMapper mapper) => _mapper = mapper;

        ///<summary>
        ///Get App Profiles
        ///</summary>
        ///<remarks>
        ///Sample request
        ///GET  /api/profile
        ///</remarks>
        ///<returns>Returns ListProfilesVm</returns>
        ///<response code="200">Success</response>
        ///<response code="401">If the user is unauthorized</response>
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

        ///<summary>
        ///Get Profile
        ///</summary>
        ///<remarks>
        ///Sample request
        ///GET  /api/profile/a9f1bdbb-3054-4ff4-8964-5590c6ba45a0
        ///</remarks>
        ///<param name="id"></param>
        ///<returns>Returns ProfileDetailsVm</returns>
        ///<response code="200">Success</response>
        ///<response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProfileDetailsVm>> Get(Guid id)
        {
            var query = new GetProfileDetailsQuery
            { UserId = UserId, Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        ///<summary>
        ///Create Profile
        ///</summary>
        ///<remarks>
        ///Sample request
        ///POST  /api/profile
        ///</remarks>
        ///<param name="createProfileDto"></param>
        ///<returns>Returns id (guid)</returns>
        ///<response code="200">Success</response>
        ///<response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProfileDto createProfileDto)
        {
            var command = _mapper.Map<CreateProfileCommand>(createProfileDto);
            command.UserId = UserId;
            var profileId = await Mediator.Send(command);
            return Ok(profileId);
        }

        ///<summary>
        ///Update Profile
        ///</summary>
        ///<remarks>
        ///Sample request
        ///PUT /api/profile
        ///</remarks>
        ///<param name="updateProfileDto"></param>
        ///<response code="204">Success</response>
        ///<response code="401">If the user is unauthorized</response>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateProfileDto updateProfileDto)
        {
            var command = _mapper.Map<UpdateProfileCommand>(updateProfileDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        ///<summary>
        ///Delete Profile
        ///</summary>
        ///<remarks>
        ///Sample request
        ///DELETE  /api/profile/a9f1bdbb-3054-4ff4-8964-5590c6ba45a0
        ///</remarks>
        ///<param name="id"></param>
        ///<response code="204">Success</response>
        ///<response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
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
