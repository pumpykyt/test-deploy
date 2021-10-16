using System.Threading.Tasks;
using API.Routes;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost(ApiRoutes.Create)]
        public async Task<IActionResult> CreateRoleAsync([FromQuery] string role)
        {
            await _roleService.CreateRoleAsync(role);
            return Ok();
        }

        [HttpGet(ApiRoutes.Get)]
        public async Task<IActionResult> GetRolesAsync()
        {
            var result = await _roleService.GetRolesAsync();
            return Ok(result);
        }
    }
}