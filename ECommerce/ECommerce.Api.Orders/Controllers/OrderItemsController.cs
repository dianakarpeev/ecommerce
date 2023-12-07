using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

/*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Diana Karpeev - 2059788
* Date: 		14 November 2023
* Class Name: 	OrderItemsController.cs
* Description: 	Creates endpoints to retrieve either the entire collection or a single item from it.
   */

namespace ECommerce.Api.Orders.Controllers
{
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemProvider orderItemProvider;

        public OrderItemsController(IOrderItemProvider orderItemProvider)
        {
            this.orderItemProvider = orderItemProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderItemsAsync()
        {
            var result = await orderItemProvider.GetOrderItemsAsync();
            if (result.IsSuccess)
                return Ok(result);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemAsync(int id)
        {
            var result = await orderItemProvider.GetOrderItemAsync(id);
            if (result.IsSuccess) 
                return Ok(result);

            return NotFound();
        }
    }
}