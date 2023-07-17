using Microsoft.AspNetCore.Identity;
using MyQuizlet.Domain.Entities;

namespace MyQuizlet.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ICollection<Deck>? Decks { get; set; }
    }
}
