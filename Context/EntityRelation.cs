using Microsoft.EntityFrameworkCore;
using TaskManagement.Model;

namespace TaskManagement.Context
{
    public class EntityRelation
    {
        private ModelBuilder _modelBuilder;

        public EntityRelation(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
        public void Configure()
        {
            _modelBuilder.Entity<User>()
                .HasOne(p => p.ProfileUser)
                .WithOne(u => u.User)
                .HasForeignKey<ProfileUser>(p => p.UserId);

            _modelBuilder.Entity<Model.Task>()
                .HasOne(s => s.Subject)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.SubjectId);

            _modelBuilder.Entity<Model.Task>()
                .HasOne(s => s.Status)
                .WithMany(t => t.Tasks)
                .HasForeignKey(s => s.StatusId);

            _modelBuilder.Entity<Model.Task>()
                .HasOne(u => u.Assignment)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.AssignmentId);
        }
    }
}
