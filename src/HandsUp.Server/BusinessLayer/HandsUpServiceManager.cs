using HandsUp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsUp.Server.BusinessLayer
{
    public class HandsUpEventServiceManager : IHandsUpEventServiceManager
    {
        private readonly HandsUpContext _db;

        public HandsUpEventServiceManager(HandsUpContext db)
        {
            _db = db;
        }

        public Task<HandsUpEvent> CreateEvent(HandsUpEvent handsUpEvent)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HandsUpEvent>> GetEventsAsync()
        {
            return await _db.HandsUpEvents
                .Include(o => o.CreatedByPerson)
                .ToListAsync().ConfigureAwait(false);
        }
    }
}
