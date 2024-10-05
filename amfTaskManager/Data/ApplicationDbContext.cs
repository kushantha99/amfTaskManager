using amfTaskManager.Models;
using Microsoft.EntityFrameworkCore;


namespace amfTaskManager.Data
{
    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<UserTask> UserTasks { get; set; }
        }
    

}
