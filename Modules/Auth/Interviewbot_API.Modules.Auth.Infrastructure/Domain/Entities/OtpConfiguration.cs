using Interviewbot_API.Modules.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Domain.Entities;

public class OtpConfiguration : IEntityTypeConfiguration<Otp>
{
    public void Configure(EntityTypeBuilder<Otp> builder)
    {
        builder.ToTable("Otp");
        builder.HasKey(o => o.OtpId);

        builder.Property<Guid>("OtpId").HasColumnName("OtpId");
        builder.Property<int>("OtpType").HasColumnName("OtpType");
        builder.Property<string>("Code").HasColumnName("Code");
        builder.Property<bool>("IsUsed").HasColumnName("IsUsed");
        builder.Property<DateTime>("ExpireAt").HasColumnName("ExpireAt");
        builder.Property<Guid>("UserId").HasColumnName("UserId");

        builder
            .HasOne<User>(u => u.User)
            .WithOne()
            .HasForeignKey<Otp>(t => t.UserId);
    }
}