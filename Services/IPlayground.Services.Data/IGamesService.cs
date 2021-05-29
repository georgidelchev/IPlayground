using System.Collections.Generic;

namespace IPlayground.Services.Data
{
    public interface IGamesService
    {
        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        T GetDetails<T>(int id);
    }
}
