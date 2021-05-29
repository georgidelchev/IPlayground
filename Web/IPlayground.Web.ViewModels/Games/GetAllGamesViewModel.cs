using IPlayground.Data.Models;
using IPlayground.Services.Mapping;

namespace IPlayground.Web.ViewModels.Games
{
    public class GetAllGamesViewModel : IMapFrom<Game>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string AddedByUserId { get; set; }

        public string CategoryName { get; set; }
    }
}
