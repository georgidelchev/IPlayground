using IPlayground.Services.Data;
using IPlayground.Web.ViewModels.Games;
using Microsoft.AspNetCore.Mvc;

namespace IPlayground.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesService gamesService;

        public GamesController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public IActionResult All()
        {
            var viewModel = new ListAllGamesViewModel
            {
                Games = this.gamesService.GetAll<GetAllGamesViewModel>(1, 12),
            };

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            return this.View();
        }
    }
}
