using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HostingTradingBots.Application.TradingPlatforms.Queries.GetListTradingPlatforms;
using HostingTradingBots.Application.TradingPlatforms.Queries.GetTradingPlatformDetails;
using HostingTradingBots.Application.TradingPlatforms.Commands.CreateTradingPlatform;
using HostingTradingBots.Application.TradingPlatforms.Commands.UpdateTradingPlatform;
using HostingTradingBots.Application.TradingPlatforms.Commands.DeleteTradingPlatform;
using HostingTradingBots.WebApi.Models;

namespace HostingTradingBots.WebApi.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  public class TradingPlatformController : BaseController
  {
    private readonly IMapper _mapper;
    public TradingPlatformController(IMapper mapper) => _mapper = mapper;

    ///<summary>
    ///Get List Trading Platforms
    ///</summary>
    ///<remarks>
    ///Sample request
    ///GET  /api/tradingPlatforms
    ///</remarks>
    ///<returns>Returns ListTradingPlatformsVm</returns>
    ///<response code="200">Success</response>
    ///<response code="401">If the user is unauthorized</response>
    [HttpGet]
    // [Authorize]
    public async Task<ActionResult<ListTradingPlatformsVm>> GetAll()
    {
      var query = new GetListTradingPlatformsQuery
      {
      };
      var vm = await Mediator.Send(query);
      return Ok(vm);
    }

    ///<summary>
    ///Get Trading Platform Details 
    ///</summary>
    ///<remarks>
    ///Sample request
    ///GET  /api/tradingPlatforms/a9f1bdbb-3054-4ff4-8964-5590c6ba45a0
    ///</remarks>
    ///<param name="id"></param>
    ///<returns>Returns TradingPlatformDetailsVm</returns>
    ///<response code="200">Success</response>
    ///<response code="401">If the user is unauthorized</response>
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<TradingPlatformDetailsVm>> Get(Guid id)
    {
      var query = new GetTradingPlatformDetailsQuery
      { Id = id };
      var vm = await Mediator.Send(query);
      return Ok(vm);

    }

    ///<summary>
    ///Create Trading Platform 
    ///</summary>
    ///<remarks>
    ///Sample request
    ///POST  /api/tradingPlatforms
    ///</remarks>
    ///<param name="createTradingPlatformDto"></param>
    ///<returns>Returns id (guid)</returns>
    ///<response code="200">Success</response>
    ///<response code="401">If the user is unauthorized</response>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateTradingPlatformDto createTradingPlatformDto)
    {
      var command = _mapper.Map<CreateTradingPlatformDto>(createTradingPlatformDto);
      var tradingPlatformId = await Mediator.Send(command);
      return Ok(tradingPlatformId);
    }

    ///<summary>
    ///Update Trading Platform 
    ///</summary>
    ///<remarks>
    ///Sample request
    ///PUT /api/tradingPlatforms
    ///</remarks>
    ///<param name="updateTradingPlatformDto"></param>
    ///<response code="204">Success</response>
    ///<response code="401">If the user is unauthorized</response>
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] UpdateTradingPlatformDto updateTradingPlatformDto)
    {
      var command = _mapper.Map<UpdateTradingPlatformDto>(updateTradingPlatformDto);
      await Mediator.Send(command);
      return NoContent();
    }

    ///<summary>
    ///Delete Trading Platform
    ///</summary>
    ///<remarks>
    ///Sample request
    ///DELETE  /api/tradingPlatform/a9f1bdbb-3054-4ff4-8964-5590c6ba45a0
    ///</remarks>
    ///<param name="id"></param>
    ///<response code="204">Success</response>
    ///<response code="401">If the user is unauthorized</response>
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
      var command = new DeleteTradingPlatformCommand
      {
        Id = id,
      };
      await Mediator.Send(command);
      return NoContent();
    }

  }
}
