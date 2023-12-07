using ECommerce.Api.Orders.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Interfaces
{
    public interface IOrderItemProvider
    {
        Task<(Boolean IsSuccess, IEnumerable<Models.OrderItem> OrderItems, string ErrorMessage)> GetOrderItemsAsync();
        Task<(Boolean IsSuccess, Models.OrderItem OrderItem, string ErrorMessage)> GetOrderItemAsync(int id);
    }
}
