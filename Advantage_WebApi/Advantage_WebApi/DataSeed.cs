using Advantage_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advantage_WebApi
{
    public class DataSeed
    {
        private readonly ApiContext _ctx;

        public DataSeed(ApiContext ctx)
        {
            _ctx = ctx;
        }
        public void SeedData(int nCustomers, int NOrders)
        {
            if(!_ctx.Customers.Any())
            {
                SeadCustomers(nCustomers);
                _ctx.SaveChanges();

            }
            if (!_ctx.Orders.Any())
            {
                SeadOrders(NOrders);
                _ctx.SaveChanges();

            }
            if (!_ctx.Servers.Any())
            {
                SeadServers();
                 _ctx.SaveChanges();
            }
           
        }

        private void SeadCustomers(int n)
        {
            List<CustomerModel> customers = BuildCustomerList(n);
            foreach(var c in customers)
            {
                _ctx.Customers.Add(c);
            }
        }
        private void SeadOrders(int n)
        {
            List<OrderModel> orders = BuildOrderList(n);
            foreach(var o in orders)
            { _ctx.Orders.Add(o); }
        }
        private void  SeadServers()
        {
            List<ServerModel> servers = BuildServerList();
            foreach (var s in servers)
            {
                _ctx.Servers.Add(s);
            }
        }

        private List<CustomerModel> BuildCustomerList(int n)
        {
            var customers =  new List<CustomerModel>();
            var names = new List<string>();

            for(var i=1; i<=n; i++)
            {
                var name = Helpers.MakeUniqueCustomerName(names);
                names.Add(name);

                customers.Add(new CustomerModel
                {
                    
                    Name = name,
                    Email = Helpers.MakeCustomerEmail(name),
                    State = Helpers.GetRandomState()
                });

            }
            return customers;

        }


        private List<OrderModel> BuildOrderList( int nOrders)
        {
            var orders = new List<OrderModel>();
            var rand = new Random();
            for(var i =1; i<=nOrders; i++)
            {
                var randCustomerId = rand.Next(1,_ctx.Customers.Count());
                var placed = Helpers.GetRandomOrderPlaced();
                var completed = Helpers.GetRandomOrderCompleted(placed);
                orders.Add(new OrderModel
                {
                    
                    Customer = _ctx.Customers.First(c => c.Id == randCustomerId),
                    Total = Helpers.GetRandomOrderTotal(),
                    Placed = placed,
                    Completed = completed
                });
            }
            return orders;

        }
        private List<ServerModel> BuildServerList()
        {
            return new List<ServerModel>()
            { new ServerModel
            {
                
                Name = "Dev-Web",
                isOnline = true
            },
             new ServerModel
            {
                
                Name = "Dev-Mail",
                isOnline = false
            },
              new ServerModel
            {
               
                Name = "Dev-Services",
                isOnline = true
            },
              new ServerModel
            {
            
                Name = "QA-Web",
                isOnline = true
            },
             new ServerModel
            {
              
                Name = "QA-Mail",
                isOnline = false
            },
              new ServerModel
            {
                
                Name = "QA-Services",
                isOnline = true
            },
              new ServerModel
            {
            
                Name = "Prod-Web",
                isOnline = true
            },
             new ServerModel
            {
                
                Name = "Prod-Mail",
                isOnline = false
            },
              new ServerModel
            {
               
                Name = "Prod-Services",
                isOnline = true
            }
            };
        }



    }
}
