using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Data
{
    public interface IQueueRepository
    {
        void AddTicket(Ticket ticket);
        void AddTickets(IEnumerable<Ticket> tickets);
        void Close(Ticket ticket);
        IEnumerable<Ticket> GetQueue();
        Ticket GetTicket(int id);
        IEnumerable<Ticket> GetTickets();
        IEnumerable<Category> GetCategories();
        Category GetCategory(char id);
        void AddCategory(Category c);
        void AddCategories(IEnumerable<Category> c);
        int GetLastTicketId();
    }
}
