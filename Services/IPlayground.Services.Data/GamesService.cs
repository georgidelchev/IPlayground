using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IPlayground.Data.Common.Repositories;
using IPlayground.Data.Models;
using IPlayground.Services.Mapping;
using IPlayground.Web.ViewModels.Games;

namespace IPlayground.Services.Data
{
    public class GamesService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gamesRepository;

        public GamesService(IDeletableEntityRepository<Game> gamesRepository)
        {
            this.gamesRepository = gamesRepository;
        }

        public async Task CreateAsync(CreateGameInputModel input, string userId)
        {
            var game = new Game()
            {
                AddedByUserId = userId,
                Description = input.Description,
                Price = input.Price,
                Name = input.Name,
            };

            await this.gamesRepository.AddAsync(game);
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
            => this.gamesRepository
                .All()
                .To<T>()
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

        public T GetDetails<T>(int id)
            => this.gamesRepository
                .All()
                .Where(g => g.Id == id)
                .To<T>()
                .FirstOrDefault();
    }
}
