using Microsoft.EntityFrameworkCore;
using TaskManagement.Model;

namespace TaskManagement.Context.RelationShips
{
    public  class EntityRelation
    {
        private ModelBuilder _modelBuilder;

        public EntityRelation(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
        public void Configure()
        {
            _modelBuilder.Entity<User>()
                .HasOne<ProfileUser>(p=>p.ProfileUser)
                .WithOne(u=>u.User)
                .HasForeignKey<ProfileUser>(p=>p.UserId);
        }
    }
}
