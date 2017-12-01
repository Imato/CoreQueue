using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public class TestDataProducer
    {
        public static IEnumerable<Ticket> GetTickets()
        {
            for (int i = 0; i < 10; i++)
            {
                var t = new Ticket()
                {
                    Id = i,
                    Category = 'T',
                    CreateDate = DateTime.UtcNow
                };

                yield return t;
            }
        }

        public static IEnumerable<Category> GeCategories()
        {
            var c = new Category()
            {
                Id = 'T',
                Name = "Test",
                Description = "Test"
            };
            yield return c;

        }
    }
}
