using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurent_Management.RestaurentManagement.Models;
using Restaurent_Management.RestaurentManagement.Services;
using RestSharp;

namespace Restaurent_Management.Controllers
{
    [Route("api/RestClient")]
    [ApiController]
    public class RestClientController : ControllerBase
    {
        private readonly IRestClientService _restClientService;
        public RestClientController(IRestClientService restClientService)
        {
            _restClientService = restClientService;
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _restClientService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(product);
        }


        [HttpGet("products")]
        public async Task<ActionResult> GetPosts()
        {
            try
            {
                return Ok(await _restClientService.GetAllPosts());
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost("products")]
        public async Task<IActionResult> CreatePost([FromBody] restClientViewModel postData)
        {
            if (postData == null)
            {
                return BadRequest("Invalid post data.");
            }

            var response = await _restClientService.CreatePostAsync(postData);
            return Ok(response);
        }

        [HttpPut("products/{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] restClientViewModel postData)
        {
            if (postData == null)
            {
                return BadRequest("Invalid post data.");
            }

            var response = await _restClientService.UpdatePostAsync(id, postData);
            return Ok(response);
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var isDeleted = await _restClientService.DeletePostAsync(id);

            if (!isDeleted)
            {
                return NotFound("Post not found.");
            }

            return Ok("Post deleted successfully.");
        }

       

        
    }
}
