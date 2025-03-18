using AccountManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManager.Repository.Context.Mappings;

public class AccountMapping : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Number);
        
        builder
            .Property(a => a.Balance)
            .HasPrecision(18, 2)
            .IsRequired();

        builder
            .Property(a => a.UserId)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasOne(a => a.User)
            .WithOne(u => u.Account)
            .HasForeignKey<Account>(a => a.UserId)
            .HasForeignKey<User>(u => u.AccountNumber);
    }
}
