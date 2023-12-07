using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

/*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by:   Diana Karpeev - 20 59 788
* Date: 		25 November 2023
* Class Name: 	XYZ.cs
* Description:  Controller that handles searching through the other services provided by this API.
   */


namespace ECommerce.Api.Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService) {
            this.searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchTerm term)
        {
            var result = await searchService.SearchAsync(term.CustomerId);
            if (result.IsSuccess) return Ok(result.SearchResults);
            return NotFound();
        }
    }
}
