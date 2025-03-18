using AccountManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Repository.Context.Mappings;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.PayerAccount)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.PayerAccountNumber);

        builder.HasIndex(x => x.PayerAccountNumber);

        builder
            .HasOne(x => x.PayeeAccount)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.PayeeAccountNumber);

        builder.HasIndex(x => x.PayeeAccountNumber);

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
