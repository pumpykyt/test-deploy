using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using DTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealController : ControllerBase
    {
        private readonly IDealService _dealService;

        public DealController(IDealService dealService)
        {
            _dealService = dealService;
        }

        [Authorize(Roles = "user")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateDealAsync(DealRequestDto model)
        {
            var userId = User.FindFirst("id").Value;
            var result = await _dealService.CreateDealAsync(model, userId);
            return Ok(result);
        }
        
        [HttpGet("paged")]
        public async Task<IActionResult> GetDealsPageAsync([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            var result = await _dealService.GetDealsPageAsync(pageSize, pageNumber);
            return Ok(result);
        }

        [Authorize(Roles = "user")]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteDealAsync([FromQuery] int id)
        {
            await _dealService.DeleteDealAsync(id);
            return Ok();
        }
    }
}