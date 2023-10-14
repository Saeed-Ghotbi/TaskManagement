using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Model;

namespace TaskManagement.Context.SeedData
{
    public class ProfileSeedData : IEntityTypeConfiguration<ProfileUser>
    {
        public void Configure(EntityTypeBuilder<ProfileUser> builder)
        {
            builder.HasData(new ProfileUser()
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

        }
    }
}
