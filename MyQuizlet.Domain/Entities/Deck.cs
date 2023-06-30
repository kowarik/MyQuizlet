using System.ComponentModel.DataAnnotations;

namespace MyQuizlet.Domain.Entities
{
    public class Deck : BaseEntity
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string DeckName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string Description { get; set; }

        public List<Card> Cards { get; set; } = new List<Card>();
    }
}
