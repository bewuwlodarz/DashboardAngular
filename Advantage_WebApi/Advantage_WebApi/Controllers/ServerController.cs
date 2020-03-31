using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advantage_WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Advantage_WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ServerController : Controller
    {
        private readonly ApiContext _ctx;
        public ServerController(ApiContext ctx)
        {
            _ctx = ctx;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var response = _ctx.Customers.OrderBy(c => c.Id).ToList();

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetServer")]
        public IActionResult Get(int id)
        {
            var server = _ctx.Servers.Find(id);
            return Ok(server);
        }

        [HttpPut("{id}")]
        public IActionResult Message(int id, [FromBody] ServerMessage message)
        {
            var server = _ctx.Servers.Find(id);

            if(server ==null)
            {
                return NotFound();
            }

            //Refactor: move into a service

            if(message.Payload == "activate")
            {
                server.isOnline = true;
                _ctx.SaveChanges();
            }

            if(message.Payload =="deactivate")
            {
                server.isOnline = false;
                _ctx.SaveChanges();
            }
            return new NoContentResult();
        }
    }
}