using IPlayground.Common;
using IPlayground.Services.Data;
using IPlayground.Web.ViewModels.Games;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create(CreateGameInputModel input)
        {
            return this.RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        public IActionResult All()
            => this.View(new ListAllGamesViewModel
            {
                Games = this.gamesService
                    .GetAll<GetAllGamesViewModel>(1, 12),
            });

        [HttpGet]
        public IActionResult Details(int id)
        {
            return this.View();
        }
    }
}
