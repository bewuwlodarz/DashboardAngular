using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advantage_WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advantage_WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly ApiContext _ctx;
        public OrderController(ApiContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public IActionResult Get(int pageIndex, int pageSize)
        {
            var data = _ctx.Orders.Include(o => o.Customer)
                .OrderByDescending(c => c.Placed);
            var page = new PaginatedResponse<OrderModel>(data, pageIndex, pageSize);
            var totalCount = data.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);
            var response = new
            {
                Page = page,
                TotalPages = totalPages
            };
            return Ok(response);
        }

        [HttpGet("ByState")]
        public IActionResult ByState()
        {
            var orders = _ctx.Orders.Include(o => o.Customer).ToList();
            var groupedResult = orders.GroupBy(o => o.Customer.State).ToList().Select(grp => new { State = grp.Key, Total = grp.Sum(x => x.Total) }).OrderByDescending(res => res.Total).ToList();
            return Ok(groupedResult);
        }
        [HttpGet("ByCustomer/{n}")]
        public IActionResult ByCustomer(int n)
        {
            var orders = _ctx.Orders.Include(o => o.Customer).ToList();
            var groupedResult = orders.GroupBy(o => o.Customer.Id).ToList().Select(grp => new { Name = _ctx.Customers.Find(grp.Key).Name, Total = grp.Sum(x => x.Total) }).OrderByDescending(res => res.Total).Take(n).ToList();
            return Ok(groupedResult);
        }
        [HttpGet("GetOrder/{id}", Name = "GetOrder")]
        public IActionResult GetOrder(int id)
        {
            var order = _ctx.Orders.Include(o => o.Customer).First(o => o.Id == id);
            return Ok(order);
        }
        [HttpPost]
        public IActionResult Post([FromBody] OrderModel order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
            return CreatedAtRoute("GetCustomer", order.Id, order);
        }

    }
}