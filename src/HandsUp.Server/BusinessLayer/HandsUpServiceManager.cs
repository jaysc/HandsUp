using HandsUp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<HandsUpEvent> CreateEvent(HandsUpEvent handsUpEvent)
        {
            _db.Attach(handsUpEvent);
            await _db.SaveChangesAsync();

            return handsUpEvent;
        }

        public async Task<List<HandsUpEvent>> GetEventsAsync()
        {
            return await _db.HandsUpEvents
                .Where(o => o.FinishedDate == null && !o.Deleted)
                .Include(o => o.CreatedByPerson)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<bool> RemoveEvent(int eventId)
        {
            bool result = false;

            var row = _db.HandsUpEvents.Find(eventId);
            if (row != null)
            {
                row.Deleted = true;
                await _db.SaveChangesAsync().ConfigureAwait(false);

                result = true;
            }

            return result;
        }
    }
}
