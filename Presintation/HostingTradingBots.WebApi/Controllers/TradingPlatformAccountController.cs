using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HostingTradingBots.Application.TradingPlatformAccounts.Queries.GetListTradingPlatformAccounts;
using HostingTradingBots.Application.TradingPlatformsAccounts.Queries.GetTradingPlatformAccountDetails;
using HostingTradingBots.Application.TradingPlatformAccounts.Commands.CreateTradingPlatformAccount;
using HostingTradingBots.Application.TradingPlatformAccounts.Commands.UpdateTradingPlatformAccount;
using HostingTradingBots.Application.TradingPlatformAccounts.Commands.DeleteTradingPlatformAccount;
using HostingTradingBots.WebApi.Models;

namespace HostingTradingBots.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class TradingPlatformAccountController : BaseController
    {
        private readonly IMapper _mapper;
        public TradingPlatformAccountController(IMapper mapper) => _mapper = mapper;

        ///<summary>
        ///Get List Trading Platforms Accounts
        ///</summary>
        ///<remarks>
        ///Sample request
        ///GET  /api/tradingPlatformsAccounts
        ///</remarks>
        ///<returns>Returns ListTradingPlatformsAccountsVm</returns>
        ///<response code="200">Success</response>
        ///<response code="401">If the user is unauthorized</response>
        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<ListTradingPlatformsAccountsVm>> GetAll()
        {
            var query = new GetListTradingPlatformsAccountsQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        ///<summary>
        ///Get Trading Platform Account Details 
        ///</summary>
        ///<remarks>
        ///Sample request
        ///GET  /api/tradingPlatformsAccounts/a9f1bdbb-3054-4ff4-8964-5590c6ba45a0
        ///</remarks>
        ///<param name="id"></param>
        ///<returns>Returns TradingPlatformAccountDetailsVm</returns>
        ///<response code="200">Success</response>
        ///<response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<TradingPlatformAccountDetailsVm>> Get(Guid id)
        {
            var query = new GetTradingPlatformAccountDetailsQuery
            { Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        ///<summary>
        ///Create Trading Platform Account
        ///</summary>
        ///<remarks>
        ///Sample request
        ///POST  /api/tradingPlatformsAccounts
        ///</remarks>
        ///<param name="createTradingPlatformAccountDto"></param>
        ///<returns>Returns id (guid)</returns>
        ///<response code="200">Success</response>
        ///<response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTradingPlatformAccountDto createTradingPlatformAccountDto)
        {
            var command = _mapper.Map<CreateTradingPlatformAccountDto>(createTradingPlatformAccountDto);
            var tradingPlatformId = await Mediator.Send(command);
            return Ok(tradingPlatformId);
        }

        ///<summary>
        ///Update Trading Platform Account
        ///</summary>
        ///<remarks>
        ///Sample request
        ///PUT /api/tradingPlatformsAccounts
        ///</remarks>
        ///<param name="updateTradingPlatformAccountDto"></param>
        ///<response code="204">Success</response>
        ///<response code="401">If the user is unauthorized</response>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateTradingPlatformAccountDto updateTradingPlatformAccountDto)
        {
            var command = _mapper.Map<UpdateTradingPlatformAccountDto>(updateTradingPlatformAccountDto);
            await Mediator.Send(command);
            return NoContent();
        }

        ///<summary>
        ///Delete Trading Platform Account
        ///</summary>
        ///<remarks>
        ///Sample request
        ///DELETE  /api/tradingPlatformsAccounts/a9f1bdbb-3054-4ff4-8964-5590c6ba45a0
        ///</remarks>
        ///<param name="id"></param>
        ///<response code="204">Success</response>
        ///<response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTradingPlatformAccountCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
