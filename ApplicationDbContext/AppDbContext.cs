using Microsoft.EntityFrameworkCore;
using SyncVsAsyncProgrammingIn.NETCoreAPI.Model;
using System.Collections.Generic;

namespace SyncVsAsyncProgrammingIn.NETCoreAPI.ApplicationDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

    }
}
