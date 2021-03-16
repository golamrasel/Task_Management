using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;
using Models.Models.SystemUsers;
using Models.Models.TaskInfo;

namespace DatabaseContext
{
    public class POSContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskInfo> Tasks { get; set; }

        public POSContext(DbContextOptions options) : base(options)
        {

        }

    }
}
