using System.Collections.Generic;
using System.Linq;

using IPlayground.Data.Common.Repositories;
using IPlayground.Data.Models;
using IPlayground.Services.Mapping;

namespace IPlayground.Services.Data
{
    public class GamesService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gamesRepository;

        public GamesService(IDeletableEntityRepository<Game> gamesRepository)
        {
            this.gamesRepository = gamesRepository;
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
