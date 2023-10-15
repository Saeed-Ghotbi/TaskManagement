using Microsoft.EntityFrameworkCore;
using TaskManagement.Model;
using Task = TaskManagement.Model.Task;

namespace TaskManagement.Context
{
    public class EntitySeedData
    {
        private ModelBuilder _modelBuilder;

        public EntitySeedData(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
        public void Configure()
        {

            _modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                IsActive = true,
                Password = "saeed123",
            },
                new User()
                {
                    Id = 2,
                    IsActive = true,
                    Password = "amir123",
                });

            _modelBuilder.Entity<ProfileUser>().HasData(new ProfileUser()
            {
                Id = 1,
                UserId = 1,
                FirstName = "Saeed",
                LastName = "Ghotbi",
                Email = "SaeedGhotbi@outlook.com",
                PhoneNumber = "09380883666"
            }, new ProfileUser()
            {
                Id = 2,
                UserId = 2,
                FirstName = "Amir",
                LastName = "Tarbaran",
                Email = "amirTarbaran@outlook.com",
                PhoneNumber = "09154578541"
            });

            _modelBuilder.Entity<Task>().HasData(new Task()
            {
                Id = 1,
                Title = "رفع باگ صفحه ادمین",
                Description = "باگ صفحه ادمین هنگام لاگین مشکل دارد.",
                SubjectId = 1,
                StatusId = 1,
                AssignmentId = 1,
            });

            _modelBuilder.Entity<Subject>().HasData(new Subject()
            {
                Id = 1,
                Title = "فنی",
            });

            _modelBuilder.Entity<Status>().HasData(new Status()
            {
                Id = 1,
                Title = "دیده نشده",
            });

        }
    }
}
