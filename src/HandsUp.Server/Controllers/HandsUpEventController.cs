using Microsoft.AspNetCore.Mvc;
using HandsUp.Shared.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using HandsUp.Server.BusinessLayer;

namespace HandsUp.Server.Controllers
{
    [Route("events")]
    [ApiController]
    public class HandsUpEventController : ControllerBase
    {
        private readonly IHandsUpEventServiceManager _handsUpEventServiceManager;
        public HandsUpEventController(IHandsUpEventServiceManager handsUpEventServiceManager)
        {
            _handsUpEventServiceManager = handsUpEventServiceManager ?? throw new ArgumentNullException(nameof(handsUpEventServiceManager));
        }

        [HttpGet]
        public async Task<ActionResult<List<HandsUpEvent>>> GetEvents()
        {
            return await _handsUpEventServiceManager.GetEventsAsync().ConfigureAwait(false);
        }


        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<HandsUpEvent>> CreateEvent([FromBody] HandsUpEvent handsUpEvent)
        {
            handsUpEvent.CreatedDate = DateTime.UtcNow;

            return await _handsUpEventServiceManager.CreateEvent(handsUpEvent).ConfigureAwait(false);
        }

        [Route("remove/{eventId}")]
        [HttpGet]
        public async Task<ActionResult> RemoveEvent(int eventId)
        {
            //todo return error if it can't find the row
            var result = await _handsUpEventServiceManager.RemoveEvent(eventId).ConfigureAwait(false);

            return new OkObjectResult(result);
        }
    }
}
