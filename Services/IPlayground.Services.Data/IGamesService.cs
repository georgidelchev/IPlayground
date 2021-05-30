using System.Collections.Generic;
using System.Threading.Tasks;

using IPlayground.Web.ViewModels.Games;

namespace IPlayground.Services.Data
{
    public interface IGamesService
    {
        Task CreateAsync(CreateGameInputModel input, string userId);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        T GetDetails<T>(int id);
    }
}
