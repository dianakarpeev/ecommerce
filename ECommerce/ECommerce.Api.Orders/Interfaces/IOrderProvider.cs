using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ECommerce.Api.Orders.Interfaces
{
    public interface IOrderProvider
    {
        Task<(Boolean IsSuccess, IEnumerable<Models.Order> Order, string ErrorMessage)> GetOrdersAsync();
        Task<(Boolean IsSuccess, Models.Order Order, string ErrorMessage)> GetOrderAsync(int id);
    }
}
