using System;
using AccountManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManager.Repository.Context.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .HasMaxLength(100);

        builder
            .Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(u => u.AccountNumber)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasOne(u => u.Account)
            .WithOne(a => a.User)
            .HasForeignKey<Account>(a => a.UserId);
    }
}
