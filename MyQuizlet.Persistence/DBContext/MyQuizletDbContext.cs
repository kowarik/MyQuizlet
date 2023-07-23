using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyQuizlet.Domain.Entities;
using MyQuizlet.Domain.IdentityEntities;
using MyQuizlet.Persistence.DbConfiguration;

namespace MyQuizlet.Persistence.DBContext
{
    public class MyQuizletDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public MyQuizletDbContext(DbContextOptions<MyQuizletDbContext> options) : base(options)
        {
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardsConfiguration());
            modelBuilder.ApplyConfiguration(new DecksConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in base.ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
