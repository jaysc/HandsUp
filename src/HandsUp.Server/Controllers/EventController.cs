using Microsoft.AspNetCore.Mvc;
using HandsUp.Shared.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;

namespace HandsUp.Server.Controllers
{
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly HandsUpContext _db;

        public EventController (HandsUpContext db)
        {
            _db = db;
        }

        [Route("events")]
        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetEvents()
        {
            return await _db.Events
                .Include(o => o.Name)
                .Include(o => o.Location)
                .Include(o => o.Date)
                .Include(o => o.Description)
                .Include(o => o.Finished)
                .ToListAsync();
        }
    }
}
