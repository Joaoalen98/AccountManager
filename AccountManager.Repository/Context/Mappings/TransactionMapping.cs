using AccountManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Repository.Context.Mappings;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasMaxLength(100);

        builder
            .HasOne(x => x.Account)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.AccountNumber);

        builder.HasIndex(x => x.AccountNumber);

        builder
            .Property(x => x.AccountNumber)
            .HasMaxLength(100);

        builder
            .Property(x => x.Description)
            .HasMaxLength(250);

        builder
            .Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder
            .Property(x => x.Date)
            .IsRequired();

        builder.HasIndex(x => x.Date);
    }
}
