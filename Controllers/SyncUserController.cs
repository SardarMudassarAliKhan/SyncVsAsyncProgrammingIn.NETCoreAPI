using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SyncVsAsyncProgrammingIn.NETCoreAPI.IRepository;

namespace SyncVsAsyncProgrammingIn.NETCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncUserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public SyncUserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                // Synchronous database call
                var user = _userRepository.GetUserByIdSync(id);

                if(user == null)
                {
                    return NotFound(); // 404 Not Found
                }

                return Ok(user); // 200 OK with user details
            }
            catch(Exception ex)
            {
                // Handle exceptions
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
