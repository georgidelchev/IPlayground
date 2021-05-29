using System.Collections.Generic;

namespace IPlayground.Web.ViewModels.Games
{
    public class ListAllGamesViewModel
    {
        public IEnumerable<GetAllGamesViewModel> Games { get; set; }
    }
}
