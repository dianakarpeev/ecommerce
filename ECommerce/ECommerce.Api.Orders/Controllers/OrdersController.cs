using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Providers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

/*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Diana Karpeev - 2059788
* Date: 		25 November 2023
* Class Name: 	OrdersController.cs
* Description: 	Creates endpoints to retrieve either the entire collection or a single item from it.
   */

namespace ECommerce.Api.Orders.Controllers
{
    public class OrdersController : ControllerBase
    {
        private readonly IOrderProvider orderProvider;

        public OrdersController(IOrderProvider orderProvider)
        {
            this.orderProvider = orderProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var result = await orderProvider.GetOrdersAsync();
            if (result.IsSuccess)
                return Ok(result);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            var result = await orderProvider.GetOrderAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return NotFound();
        }
    }
}
