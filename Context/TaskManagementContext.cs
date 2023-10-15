using Microsoft.EntityFrameworkCore;
using TaskManagement.Model;

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
            EntitySeedData entitySeedData = new EntitySeedData(builder);
            EntityRelation entityRelation = new EntityRelation(builder);

            entitySeedData.Configure();
            entityRelation.Configure();
        }

        public DbSet<User> User { get; set; }
        public DbSet<ProfileUser> ProfileUser { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Model.Task> Task { get; set; }
        public DbSet<Status> Status { get; set; }


    }


}
