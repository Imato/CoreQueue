using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Queue")]
    public class QueueController : Controller
    {
        IQueueRepository _repositiry;

        public QueueController(IQueueRepository _r)
        {
            _repositiry = _r;
        }

        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            return _repositiry.GetQueue();
        }
    }
}