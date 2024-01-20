using SyncVsAsyncProgrammingIn.NETCoreAPI.Model;

namespace SyncVsAsyncProgrammingIn.NETCoreAPI.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        User GetUserByIdSync(int id);
    }
}
