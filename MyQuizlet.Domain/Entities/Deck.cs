using MyQuizlet.Domain.IdentityEntities;
using System.ComponentModel.DataAnnotations;

namespace MyQuizlet.Domain.Entities
{
    public class Deck : BaseEntity
    {
		[Required]
		[StringLength(50)]
		[RegularExpression("^[A-Za-z .,]*$")]
		public string DeckName { get; set; }


		[Required]
		[StringLength(100)]
		[RegularExpression("^[A-Za-z .,]*$")]
		public string Description { get; set; }


        public List<Card>? Cards { get; set; }


		public Guid ApplicationUserId { get; set; }
		public ApplicationUser User { get; set; }
    }
}
