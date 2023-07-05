using MyQuizlet.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyQuizlet.Domain.Entities
{
    public class Card : BaseEntity
	{
        [Required]
		[StringLength(100)]
        [RegularExpression("^[A-Za-z .]*$")]
		public string Term { get; set; }


		[Required]
		[StringLength(100)]
		[RegularExpression("^[A-Za-z .]*$")]
		public string Definition { get; set; }


        [Required]
        public EnglishLevel EnglishLevel { get; set; }


        public Guid? DeckId { get; set; }


        public Deck? Deck { get; set; }
    }
}
