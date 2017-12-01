using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public char Category { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsClosed { get; set; }
    }
}
