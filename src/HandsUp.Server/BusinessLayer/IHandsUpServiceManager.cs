using HandsUp.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsUp.Server.BusinessLayer
{
    public interface IHandsUpEventServiceManager
    {
        public Task<List<HandsUpEvent>> GetEventsAsync();
        public Task<HandsUpEvent> CreateEvent(HandsUpEvent handsUpEvent);
        public Task<bool> RemoveEvent(int eventId);

    }
}
