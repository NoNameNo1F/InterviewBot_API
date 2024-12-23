using Interviewbot_API.Modules.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Domain.Entities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(o => o.Id);

        builder.Property<Guid>("Id").HasColumnName("Id");
        builder.Property<string>("Email").HasColumnName("Email");
        builder.Property<string>("FirstName").HasColumnName("FirstName");
        builder.Property<string>("LastName").HasColumnName("LastName");
        builder.Property<DateTime>("DoB").HasColumnName("DoB");
        builder.Property<string>("Password").HasColumnName("Password");
        builder.Property<string>("PhoneNumber").HasColumnName("PhoneNumber").IsRequired(false);
    }
}