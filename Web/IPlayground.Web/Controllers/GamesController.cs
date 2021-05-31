using System.Security.Claims;
using System.Threading.Tasks;

using IPlayground.Common;
using IPlayground.Services.Data;
using IPlayground.Web.ViewModels.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace IPlayground.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesService gamesService;
        private readonly IWebHostEnvironment environment;

        public GamesController(
            IGamesService gamesService,
            IWebHostEnvironment environment)
        {
            this.gamesService = gamesService;
            this.environment = environment;
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(CreateGameInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var wwwrootPath = this.environment
                .WebRootPath;

            await this.gamesService.CreateAsync(input, userId, wwwrootPath);

            return this.RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        public IActionResult All()
        {
            var viewModel = new ListAllGamesViewModel
            {
                Games = this.gamesService
                    .GetAll<GetAllGamesViewModel>(1, 12),
            };

            return this.View(viewModel);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            return this.View();
        }
    }
}
