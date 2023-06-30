using MyQuizlet.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyQuizlet.Domain.Entities
{
    public class Card : BaseEntity
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string Term { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string Definition { get; set; }
        [Required]
        public EnglishLevel EnglishLevel { get; set; }

        public Guid? DeckId { get; set; }
        public Deck? Deck { get; set; }
    }
}
