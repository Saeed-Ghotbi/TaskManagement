using Microsoft.EntityFrameworkCore;
using TaskManagement.Context.RelationShips;
using TaskManagement.Context.SeedData;
using TaskManagement.Model;
using Task = TaskManagement.Model.Task;

namespace TaskManagement.Context
{
    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          UsersSeedData usersSeedData = new UsersSeedData();
          ProfileSeedData profileSeedData = new ProfileSeedData();


          usersSeedData.Configure(builder.Entity<User>());
          profileSeedData.Configure(builder.Entity<ProfileUser>());


          EntityRelation entityRelation = new EntityRelation(builder);

          entityRelation.Configure();
        }

        public DbSet<User> User { get; set; }
        public DbSet<ProfileUser> ProfileUser { get; set; }
        //public DbSet<Subject> Subject { get; set; }
        //public DbSet<Task> Task { get; set; }
        //public DbSet<Status> Status { get; set; }

       
    }

   
}
