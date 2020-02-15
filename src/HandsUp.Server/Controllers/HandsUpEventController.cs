using Microsoft.AspNetCore.Mvc;
using HandsUp.Shared.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using HandsUp.Server.BusinessLayer;

namespace HandsUp.Server.Controllers
{
    [ApiController]
    public class HandsUpEventController : ControllerBase
    {
        private readonly IHandsUpEventServiceManager _handsUpEventServiceManager;
        public HandsUpEventController(IHandsUpEventServiceManager handsUpEventServiceManager)
        {
            _handsUpEventServiceManager = handsUpEventServiceManager ?? throw new ArgumentNullException(nameof(handsUpEventServiceManager));
        }

        [Route("events")]
        [HttpGet]
        public async Task<ActionResult<List<HandsUpEvent>>> GetEvents()
        {
            return await _handsUpEventServiceManager.GetEventsAsync().ConfigureAwait(false);
        }


        [Route("event")]
        [HttpPost]
        public async Task<ActionResult<HandsUpEvent>> CreateEvent([FromBody] HandsUpEvent handsUpEvent)
        {
            handsUpEvent.CreatedDate = DateTime.UtcNow;

            return handsUpEvent;

            return await _handsUpEventServiceManager.CreateEvent(handsUpEvent);
        }
    }
}
