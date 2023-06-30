using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyQuizlet.Domain.Entities;

namespace MyQuizlet.Persistence.DbConfiguration
{
    public class DecksConfiguration : IEntityTypeConfiguration<Deck>
    {
        public void Configure(EntityTypeBuilder<Deck> builder)
        {
            builder.HasData(
                new Deck
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    DeckName = "MyTestDeck1",
                    Description = "this is my deck",
                    Cards = { }
                }
            ); ;
            builder.HasData(
                new Deck
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    DeckName = "MyTestDeck2",
                    Description = "this is my deck",
                    Cards = { }
                }
            );
        }
    }
}
