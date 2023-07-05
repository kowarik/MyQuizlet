using AutoMapper;
using MyQuizlet.Application.CQRSFeatures.Deck.Commands.CreateDeck;
using MyQuizlet.Application.CQRSFeatures.Deck.Commands.UpdateDeck;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetAllDecks;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckById;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckCardsByDeckId;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckNames;
using MyQuizlet.Domain.Entities;

namespace MyQuizlet.Application.MappingProfiles
{
    public class DeckProfile : Profile
    {
        public DeckProfile()
        {
            CreateMap<Deck, GetAllDecksDto>();
            CreateMap<Deck, GetDeckByIdDto>();
            CreateMap<Deck, GetDeckNamesDto>();
            CreateMap<Deck, GetDeckCardsByDeckIdDto>();
            CreateMap<CreateDeckCommand, Deck>();
            CreateMap<UpdateDeckCommand, Deck>();
        }
    }
}
