using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyQuizlet.Domain.Entities;
using MyQuizlet.Domain.Enums;

namespace MyQuizlet.Persistence.DbConfiguration
{
    public class CardsConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasData(
                new Card
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    Term = "Apple",
                    Definition = "Яблоко",
                    EnglishLevel = EnglishLevel.A1,
                },
                new Card
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    Term = "Test",
                    Definition = "Test",
                    EnglishLevel = EnglishLevel.A1,
                }
            );
            builder.Property(q => q.Term)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
