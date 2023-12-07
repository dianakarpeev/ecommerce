using ECommerce.Api.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

/*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by:   Diana Karpeev - 20 59 788
* Date: 		25 November 2023
* Class Name: 	XYZ.cs
* Description:  Controller that handles return products (single or all of them)
   */

namespace ECommerce.Api.Products.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider productsProvider;

        public ProductsController(IProductsProvider productsProvider)
        {
            this.productsProvider = productsProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await productsProvider.GetProductsAsync();
            if (result.IsSuccess)
                return Ok(result.Products);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await productsProvider.GetProductAsync(id);
            if (result.IsSuccess)
                return Ok(result.Product);

            return NotFound();
        }
    }
}
