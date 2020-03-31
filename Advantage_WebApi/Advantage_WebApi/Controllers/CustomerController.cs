using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advantage_WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Advantage_WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ApiContext _ctx;
        public CustomerController(ApiContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var data = _ctx.Customers.OrderBy(c => c.Id);

            return Ok(data);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get(int id)
        {
            var customer = _ctx.Customers.Find(id);
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult Post([FromBody] CustomerModel customer)
        {
            if(customer == null)
            {
                return BadRequest();
            }

            _ctx.Customers.Add(customer);
            _ctx.SaveChanges();
            return CreatedAtRoute("GetCustomer", customer.Id, customer);
        }

    }
}