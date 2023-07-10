using MediatR;
using MyQuizlet.Application.Enums;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.GetNextOrPreviousCard
{
    public record GetNextOrPreviousCardQuery(Sorting Sorting, PositionAction PositionAction, Guid DeckId, Guid CardId) : IRequest<GetNextOrPreviousCardDto>;
}
