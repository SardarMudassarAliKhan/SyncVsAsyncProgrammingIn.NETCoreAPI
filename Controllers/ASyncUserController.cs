using Microsoft.AspNetCore.Mvc;
using SyncVsAsyncProgrammingIn.NETCoreAPI.IRepository;

namespace SyncVsAsyncProgrammingIn.NETCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ASyncUserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public ASyncUserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet(nameof(GetUserByIdAsync))]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            try
            {
                // Asynchronous database call
                var user = await _userRepository.GetUserByIdAsync(id);

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
