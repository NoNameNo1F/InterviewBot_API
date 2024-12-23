using Interviewbot_API.Modules.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Domain.Entities;

public class TokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshToken");
        builder.HasKey(o => o.TokenId);

        builder.Property<Guid>("TokenId").HasColumnName("TokenId");
        builder.Property<string>("Secret").HasColumnName("Secret");
        builder.Property<bool>("IsUsed").HasColumnName("IsUsed");
        builder.Property<DateTime>("ExpireAt").HasColumnName("ExpireAt");
        builder.Property<Guid>("UserId").HasColumnName("UserId");

        builder
            .HasOne<User>(u => u.User)
            .WithOne()
            .HasForeignKey<RefreshToken>(t => t.UserId);
    }
}