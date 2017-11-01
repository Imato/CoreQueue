using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Data
{
    public interface IQueueRepository
    {
        void Add(Ticket ticket);
        void Close(Ticket ticket);
        IEnumerable<Ticket> GetQueue();
    }
}
