using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class QueueSimpleRepository : IQueueRepository
    {
        Dictionary<int, Ticket> _tickets;
        Dictionary<char, Category> _categories;

        public QueueSimpleRepository()
        {
            _tickets = new Dictionary<int, Ticket>();
            _categories = new Dictionary<char, Category>();

        }
        public void AddTicket(Ticket ticket)
        {
            if (_tickets.Keys.FirstOrDefault(x => x == ticket.Id) != null)
                _tickets.Remove(ticket.Id);
            _tickets.Add(ticket.Id, ticket);
        }

        public void AddTickets(IEnumerable<Ticket> tickets)
        {
            tickets.All(t => { _tickets.Add(t.Id, t); return true; });            
        }

        public void Close(Ticket ticket)
        {
            //_repository[ticket.Id].IsClosed = true;
            _tickets.Remove(ticket.Id);
        }

        public IEnumerable<Ticket> GetQueue()
        {
            return _tickets.Values.Where(t => !t.IsClosed);
        }

        public Ticket GetTicket(int id)
        {
            return _tickets[id];
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories.Values;
        }

        public Category GetCategory(char id)
        {
            return _categories[id];
        }

        public void AddCategory(Category c)
        {
            _categories.Add(c.Id, c);
        }

        public void AddCategories(IEnumerable<Category> cats)
        {
            cats.All(c => { _categories.Add(c.Id, c); return true; });
        }

        public int GetLastTicketId()
        {
            return _tickets.Keys.Max();
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _tickets.Values;
        }
    }   
    
}
