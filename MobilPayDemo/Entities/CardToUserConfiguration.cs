using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobilPayDemo.Data;

namespace MobilPayDemo.Entities
{
    public class CardToUserConfiguration : IEntityTypeConfiguration<CardToUser>
    {
        public void Configure(EntityTypeBuilder<CardToUser> builder)
        {
            builder.ToTable(nameof(ApplicationDbContext.CardToUsers));

            builder
                .HasKey(p => new
                {
                    p.CardId,
                    p.UserId
                });

            builder
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            builder
                .HasOne(p => p.Card)
                .WithMany()
                .HasForeignKey(p => p.CardId);
        }
    }
}
