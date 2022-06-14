using BeerHub.Interfaces;
using BeerHub.Models;

namespace BeerHub.Mappers
{
    public class AlcoholMapper
    {
        public AlcoholMapper()
        {

        }

        public Alcohol AlcoholDTOToAlcohol(AlcoholDTO alcoholDTO)
        {
            Alcohol a = new Alcohol();
            a.ID = alcoholDTO.AlcoholId;
            a.Name = alcoholDTO.Name;
            a.Type = alcoholDTO.Type;
            a.Percentage = alcoholDTO.Percentage;
            a.Calories = alcoholDTO.Calories;
            a.SpecificType = alcoholDTO.SpecificType;
            a.Upvote = alcoholDTO.Upvote;
            a.Downvote = alcoholDTO.Downvote;
            return a;
        }

        public AlcoholDTO AlcoholToAlcoholDTO(Alcohol alcohol)
        {
            AlcoholDTO a = new AlcoholDTO();
            a.AlcoholId = alcohol.ID;
            a.Name = alcohol.Name;
            a.Type = alcohol.Type;
            a.SpecificType = alcohol.SpecificType;
            a.Calories = alcohol.Calories;
            a.Percentage = (float) alcohol.Percentage;
            a.Upvote = alcohol.Upvote;
            a.Downvote = alcohol.Downvote;
            return a;
        }
    }
}
