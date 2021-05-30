using System.Linq;

using AutoMapper;
using IPlayground.Data.Models;
using IPlayground.Services.Mapping;

namespace IPlayground.Web.ViewModels.Games
{
    public class GetAllGamesViewModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string AddedByUserId { get; set; }

        public string CategoryName { get; set; }

        public string PictureExtension { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Game, GetAllGamesViewModel>()
                .ForMember(m => m.PictureExtension, opt => opt.MapFrom(p => p.Pictures.FirstOrDefault().Extension));
        }
    }
}
