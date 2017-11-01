using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class QueueSimpleRepository : IQueueRepository
    {
        Dictionary<int, Ticket> _repository;

        public QueueSimpleRepository()
        {
            _repository = new Dictionary<int, Ticket>();
            AddTestDate();
        }
        public void Add(Ticket ticket)
        {
            _repository.Add(ticket.Id, ticket);
        }

        public void Close(Ticket ticket)
        {
            _repository[ticket.Id].IsClosed = true;
        }

        public IEnumerable<Ticket> GetQueue()
        {
            return _repository.Values.Where(t => !t.IsClosed);
        }

        private void AddTestDate()
        {
            var t = new Ticket()
            {
                Id = 1,
                Prefix = "T",
                CreateDate = new DateTime()
            };
            _repository.Add(t.Id, t);
            t = new Ticket()
            {
                Id = 2,
                Prefix = "T",
                CreateDate = new DateTime()
            };
            _repository.Add(t.Id, t);
        }
    }
}
