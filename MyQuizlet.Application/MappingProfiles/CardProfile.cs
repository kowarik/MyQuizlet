using AutoMapper;
using MyQuizlet.Application.CQRSFeatures.Card.Commands.CreateCard;
using MyQuizlet.Application.CQRSFeatures.Card.Commands.UpdateCard;
using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetAllCards;
using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetCardById;
using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetNextOrPreviousCard;
using MyQuizlet.Domain.Entities;
using MyQuizlet.Domain.Enums;

namespace MyQuizlet.Application.MappingProfiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, GetAllCardsDto>()
                .ForMember(dest => dest.EnglishLevel, opt => opt.MapFrom(src => MapEnglishLevelEnumToString(src.EnglishLevel)));
            CreateMap<Card, GetCardByIdDto>()
                .ForMember(dest => dest.EnglishLevel, opt => opt.MapFrom(src => MapEnglishLevelEnumToString(src.EnglishLevel)));
            CreateMap<Card, GetNextOrPreviousCardDto>()
                .ForMember(dest => dest.EnglishLevel, opt => opt.MapFrom(src => MapEnglishLevelEnumToString(src.EnglishLevel)));
            CreateMap<CreateCardCommand, Card>()
                .ForMember(dest => dest.EnglishLevel, opt => opt.MapFrom(src => MapEnglishLevelStringToEnum(src.EnglishLevel)));
            CreateMap<UpdateCardCommand, Card>()
                .ForMember(dest => dest.EnglishLevel, opt => opt.MapFrom(src => MapEnglishLevelStringToEnum(src.EnglishLevel)));
        }

        private static EnglishLevel MapEnglishLevelStringToEnum(string englishLevel)
        {
            if (Enum.TryParse(englishLevel, out EnglishLevel level))
                return level;
            return EnglishLevel.None;
        }

        private static string MapEnglishLevelEnumToString(EnglishLevel englishLevel)
        {
            return englishLevel.ToString();
        }
    }
}
