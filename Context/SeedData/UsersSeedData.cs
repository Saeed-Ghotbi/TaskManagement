using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Model;

namespace TaskManagement.Context.SeedData
{
    public class UsersSeedData : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User()
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

        }
    }
}
