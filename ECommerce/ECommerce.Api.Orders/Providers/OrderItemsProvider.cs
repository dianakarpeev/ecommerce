using AutoMapper;
using ECommerce.Api.Orders.Database;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Orders.Providers
{
    public class OrderItemsProvider : IOrderItemProvider
    {
        private readonly OrdersDbContext dbContext;
        private readonly ILogger<OrderItemsProvider> logger;
        private readonly IMapper mapper;

        public OrderItemsProvider(OrdersDbContext dbContext, ILogger<OrderItemsProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.OrderItems.Any())
            {
                dbContext.OrderItems.Add(new Database.OrderItem() { Id = 1, OrderId = 1, ProductId = 3, Quantity = 5, UnitPrice = 150});
                dbContext.OrderItems.Add(new Database.OrderItem() { Id = 2, OrderId = 2, ProductId = 2, Quantity = 15, UnitPrice = 5});
                dbContext.OrderItems.Add(new Database.OrderItem() { Id = 3, OrderId = 5, ProductId = 4, Quantity = 1, UnitPrice = 2000});
                dbContext.OrderItems.Add(new Database.OrderItem() { Id = 4, OrderId = 1, ProductId = 1, Quantity = 32, UnitPrice = 100});
                dbContext.OrderItems.Add(new Database.OrderItem() { Id = 5, OrderId = 5, ProductId = 3, Quantity = 10, UnitPrice = 150});
                dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, Models.OrderItem OrderItem, string ErrorMessage)> GetOrderItemAsync(int id)
        {
            try
            {
                var orderItem = await dbContext.OrderItems.FirstOrDefaultAsync(orderItem => orderItem.Id == id);
                if (orderItem != null)
                {
                    var result = mapper.Map<Database.OrderItem, Models.OrderItem>(orderItem);
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

        public async Task<(bool IsSuccess, IEnumerable<Models.OrderItem> OrderItems, 
            string ErrorMessage)> GetOrderItemsAsync()
        {
            try
            {
                var orderItems = await dbContext.OrderItems.ToListAsync();
                if (orderItems != null && orderItems.Any())
                {
                    var result = mapper.Map<IEnumerable<Database.OrderItem>, IEnumerable<Models.OrderItem>>(orderItems);
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
