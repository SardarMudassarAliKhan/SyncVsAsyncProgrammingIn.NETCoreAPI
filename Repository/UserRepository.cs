using Microsoft.EntityFrameworkCore;
using SyncVsAsyncProgrammingIn.NETCoreAPI.ApplicationDbContext;
using SyncVsAsyncProgrammingIn.NETCoreAPI.IRepository;
using SyncVsAsyncProgrammingIn.NETCoreAPI.Model;

namespace SyncVsAsyncProgrammingIn.NETCoreAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext dbContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;   
        }

        public User GetUserByIdSync(int id)
        {
            try
            {
                // Synchronous database query
                return _dbContext.Users.FirstOrDefault(u => u.Id == id);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error in UserRepository.GetUserById: {ex.Message}");
                throw new ApplicationException("An error occurred while fetching user details. Please try again later.");
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            // Asynchronous database query
            try
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch(Exception ex)
            {

                _logger.LogError($"Error in UserRepository.GetUserById: {ex.Message}");
                throw new ApplicationException("An error occurred while fetching user details. Please try again later.");
            }
        }
    }
}
