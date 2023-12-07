using AutoMapper;
using ECommerce.Api.Orders.Database;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Orders.Providers
{
    public class OrdersProvider : IOrderProvider
    {
        private readonly OrdersDbContext dbContext;
        private readonly ILogger<OrdersProvider> logger;
        private readonly IMapper mapper;

        public OrdersProvider(OrdersDbContext dbContext, ILogger<OrdersProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Orders.Any())
            {
                dbContext.Orders.Add(new Database.Order() { Id = 1, OrderDate = DateTime.Today, CustomerId = 2, Total = 368.99});
                dbContext.Orders.Add(new Database.Order() { Id = 2, OrderDate = new DateTime(2023, 10, 23), CustomerId = 5, Total = 143.57 });
                dbContext.Orders.Add(new Database.Order() { Id = 3, OrderDate = new DateTime(2023, 04, 13), CustomerId = 1, Total = 15.83 });
                dbContext.Orders.Add(new Database.Order() { Id = 4, OrderDate = new DateTime(2023, 2, 12), CustomerId = 3, Total = 89.99 });
                dbContext.Orders.Add(new Database.Order() { Id = 5, OrderDate = new DateTime(2023, 7, 18), CustomerId = 4, Total = 2121.22 });
                dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, Models.Order Order, string ErrorMessage)> GetOrderAsync(int id)
        {
            try
            {
                var order = await dbContext.Orders.FirstOrDefaultAsync(order => order.Id == id);
                if (order != null)
                {
                    var result = mapper.Map<Database.Order, Models.Order>(order);
                    return (true, result, null);
                }

                return (false, null, "Not Found");
            }
            catch (Exception e)
            {
                logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Order> Order, string ErrorMessage)> GetOrdersAsync()
        {
            try
            {
                var orders = await dbContext.Orders.ToListAsync();
                if (orders != null && orders.Any())
                {
                    var result = mapper.Map<IEnumerable<Database.Order>, IEnumerable<Models.Order>>(orders);
                    return (true, result, null);
                }

                return (false, null, "Not Found");
            }
            catch (Exception e)
            {
                logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
