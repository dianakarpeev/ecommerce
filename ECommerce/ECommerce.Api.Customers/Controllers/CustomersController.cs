using ECommerce.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

/*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Diana Karpeev - 2059788
* Date: 		14 November 2023
* Class Name: 	CustomersController.cs
* Description: 	Creates endpoints to retrieve either the entire collection or a single item from it.
   */


namespace ECommerce.Api.Customers.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerProvider customerProvider;

        public CustomersController(ICustomerProvider customerProvider)
        {
            this.customerProvider = customerProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var result = await customerProvider.GetCustomersAsync();
            if (result.IsSuccess)
                return Ok(result);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await customerProvider.GetCustomerAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return NotFound();
        }
    }
}
