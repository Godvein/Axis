using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Axis.Api.Infrastructure.Data;
using Axis.Api.Core.Entities;
using Axis.Api.Core.Interfaces;
namespace Axis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IGenericService<User> _genericService;

        public UserController(DatabaseContext context, IGenericService<User> genericService)
        {
            _context = context;
            _genericService = genericService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _genericService.GetAllObjects();
            return Ok(users);
        }

    }
}
